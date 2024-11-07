using Custom.Engine.Agent;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.Azure.Blobs;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Teams.AI;
using Microsoft.Teams.AI.AI.Models;
using Microsoft.Teams.AI.AI.Planners;
using Microsoft.Teams.AI.AI.Prompts;
using Microsoft.Teams.AI.State;
using System.Text.Json;
using Microsoft.Teams.AI.AI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient("WebClient", client => client.Timeout = TimeSpan.FromSeconds(600));
builder.Services.AddHttpContextAccessor();

// Prepare Configuration for ConfigurationBotFrameworkAuthentication
var config = builder.Configuration.Get<ConfigOptions>();
builder.Configuration["MicrosoftAppType"] = "MultiTenant";
builder.Configuration["MicrosoftAppId"] = config.BOT_ID;
builder.Configuration["MicrosoftAppPassword"] = config.BOT_PASSWORD;

// Create the Bot Framework Authentication to be used with the Bot Adapter.
builder.Services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();

// Create the Cloud Adapter with error handling enabled.
builder.Services.AddSingleton<TeamsAdapter, AdapterWithErrorHandler>();
builder.Services.AddSingleton<IBotFrameworkHttpAdapter>(sp => sp.GetService<TeamsAdapter>());
builder.Services.AddSingleton<BotAdapter>(sp => sp.GetService<TeamsAdapter>());

//Create the storage to persist turn state
builder.Services.AddSingleton<IStorage>(
    new BlobsStorage(
        config.AZURE_STORAGE_CONNECTION_STRING,
        config.AZURE_STORAGE_BLOB_CONTAINER_NAME
        )
    );

// Create Azure OpenAI Model
builder.Services.AddSingleton<OpenAIModel>(sp => new(
    new AzureOpenAIModelOptions(
        config.AZURE_OPENAI_KEY,
        config.AZURE_OPENAI_DEPLOYMENT_NAME,
        config.AZURE_OPENAI_ENDPOINT
    )
    {
        LogRequests = true
    },
    sp.GetService<ILoggerFactory>()
));

// Create the bot as transient. In this case the ASP Controller is expecting an IBot.
builder.Services.AddTransient<IBot>(sp =>
{
    // Create loggers
    ILoggerFactory loggerFactory = sp.GetService<ILoggerFactory>();

    // Create Prompt Manager
    PromptManager prompts = new(new()
    {
        PromptFolder = "./Prompts"
    });

    // Create ActionPlanner
    ActionPlanner<TurnState> planner = new(
        options: new(
            model: sp.GetService<OpenAIModel>(),
            prompts: prompts,
            defaultPrompt: async (context, state, planner) =>
            {
                PromptTemplate template = prompts.GetPrompt("Chat");

                var dataSources = template.Configuration.Completion.AdditionalData["data_sources"];
                var dataSourcesString = JsonSerializer.Serialize(dataSources);

                var replacements = new Dictionary<string, string>
                {
                    { "$azure-search-key$", config.AZURE_SEARCH_KEY },
                    { "$azure-search-index-name$", config.AZURE_SEARCH_INDEX_NAME },
                    { "$azure-search-endpoint$", config.AZURE_SEARCH_ENDPOINT },
                };

                foreach (var replacement in replacements)
                {
                    dataSourcesString = dataSourcesString.Replace(replacement.Key, replacement.Value);
                }

                dataSources = JsonSerializer.Deserialize<JsonElement>(dataSourcesString);
                template.Configuration.Completion.AdditionalData["data_sources"] = dataSources;

                return await Task.FromResult(template);
            }
        )
        { LogRepairs = true },
        loggerFactory: loggerFactory
    );

    AIOptions<TurnState> options = new(planner)
    {
        EnableFeedbackLoop = true
    };

    Application<TurnState> app = new ApplicationBuilder<TurnState>()
        .WithAIOptions(options)
        .WithStorage(sp.GetService<IStorage>())
        .Build();

    app.OnMessage("/new", MessageHandlers.NewChat);

    app.OnFeedbackLoop(FeedbackHandler.OnFeedback);

    app.AI.ImportActions(new Actions());

    return app;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();