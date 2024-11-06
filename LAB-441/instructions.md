# Lab 441 - Code-first development for Copilot Agents

# Create a declarative agent for Microsoft 365

In this lab you create a declarative agent for Microsoft 365 which can answer product support questions using information stored in documents in Microsoft 365:

- **Create**: Create a declarative agent project and use Teams Toolkit in Visual Studio Code.
- **Custom instructions**: Shape responses by defining custom instructions.
- **Custom grounding**: Add extra context to the agent by configuring grounding data.
- **Conversation starters**: Define prompts for starting new conversations.
- **Provision**: Upload your declarative agent to Microsoft 365 Copilot and validate the results.

## Example scenario

Suppose you work in a customer support team. You and your team handle queries about products that your organization makes from customers. You want to improve response times and provide a better experience. You store documents in a document library on a SharePoint Online site that contains product specifications, frequently asked questions, and policies for handling repairs, returns, and warranties. You want to be able to use natural language to query information in these documents and get answers quickly to customer queries.

## Open the starter project

Start by opening the starter project in Visual Studio Code.

1. Open **Visual Studio Code**.
1. Expand the **File** menu and select **Open folder...**.
1. In the **File picker** dialog, on the left hand menu expand **This PC**, open **Local Disk (C:\)**, select **da-product-support**, then select **Select folder**.
1. In the **Workspace Trust** dialog, select **Yes, I trust the authors**.

The starter project contains a Teams Toolkit project that includes a declarative agent.

- In the project root folder, open **README.md** file. Examine the contents for more information about the project structure.

!IMAGE[create-complete.png](instructions275666/create-complete.png)

## Examine declarative agent manifest

The declarative agent manifest defines the configuration of the agent.

- Open the **appPackage/declarativeAgent.json** file and examine the contents:

```json
{
    "$schema": "https://aka.ms/json-schemas/agent/declarative-agent/v1.0/schema.json",
    "version": "v1.0",
    "name": "da-product-support",
    "description": "Declarative agent created with Teams Toolkit",
    "instructions": "$[file('instruction.txt')]"
}
```

You define **instructions** that determines how the agent should behave and shape its responses.

The value of the **instructions** property contains a reference to a file named **instruction.txt**. The **$[file(path)]** function is provided by Teams Toolkit. The contents of the **instruction.txt** are included in the declarative agent manifest file when provisioned to Microsoft 365.

- In the **appPackage** folder, open **instruction.txt** file and review the contents:

```md
You are a declarative agent and were created with Team Toolkit. You should start every response and answer to the user with "Thanks for using Teams Toolkit to create your declarative agent!\n\n" and then answer the questions and help the user.
```

## Update the declarative agent manifest

Let's update the **name** and **description** properties to be more relevant to our scenario.

1. In the **appPackage** folder, open **declarativeAgent.json** file.
1. Update the **name** property value to **Product support**.
1. Update the **description** property value to **Product support agent that can help answer customer queries about Contoso Electronics products**.
1. Save your changes.

The updated file should have the following contents:

```json
{
    "$schema": "https://aka.ms/json-schemas/agent/declarative-agent/v1.0/schema.json",
    "version": "v1.0",
    "name": "Product support",
    "description": "Product support agent that can help answer customer queries about Contoso Electronics products",
    "instructions": "$[file('instruction.txt')]"
}
```

## Upload the declarative agent to Microsoft 365

Next, upload your declarative agent to your Microsoft 365 tenant.

In Visual Studio Code:

1. In the **Activity Bar**, open the **Teams Toolkit** extension.

    !IMAGE[teams-toolkit-open.png](instructions275666/teams-toolkit-open.png)

1. In the **Lifecycle** section, select **Provision**.

    !IMAGE[provision.png](instructions275666/provision.png)

1. In the prompt, select **Sign in** and follow the prompts to sign in to your Microsoft 365 tenant using Teams Toolkit. The provisioning process starts automatically after you sign in.

    !IMAGE[provision-sign-in.png](instructions275666/provision-sign-in.png)

    !IMAGE[provision-in-progress.png](instructions275666/provision-in-progress.png)

1. Wait for the upload to complete before continuing.

    !IMAGE[provision-complete.png](instructions275666/provision-complete.png)

Next, review the output of the provisioning process.

- In the **appPackage/build** folder, open **declarativeAgent.dev.json** file.

Notice that the **instructions** property value contains the contents of the **instruction.txt** file. The **declarativeAgent.dev.json** file is included in the **appPackage.dev.zip** file along with the **manifest.dev.json**, **color.png**, and **outline.png** files. The **appPackage.dev.zip** file is uploaded to Microsoft 365.

## Test the declarative agent in Microsoft 365 Copilot

Next, let's run the declarative agent in Microsoft 365 Copilot and validate its functionality in both the **in-context** and **immersive** experiences.

In Visual Studio Code:

1. In the **Activity Bar**, switch to the **Run and Debug** view.

    !IMAGE[debug-open.png](instructions275666/debug-open.png)

1. Select the **Start Debugging** button next to the configuration's dropdown, or press <kbd>F5</kbd>. A new browser window is launched and navigates to Microsoft 365 Copilot.

    !IMAGE[debug-start.png](instructions275666/debug-start.png)

    !IMAGE[debug-in-progress.png](instructions275666/debug-in-progress.png)

    !IMAGE[debug-microsoft-365-copilot.png](instructions275666/debug-microsoft-365-copilot.png)

Continuing in the browser, let's test the **in-context** experience.

1. In **Microsoft 365 Copilot**, in the message box enter the <kbd>@</kbd> symbol. The flyout appears with a list of available agents.

    !IMAGE[test-in-context-agent-flyout.png](instructions275666/test-in-context-agent-flyout.png)

1. In the flyout, select **Product support**. Notice the status message above the message box. It displays **Chatting with Product support**, which signifies that you're using the in-context experience of the agent.

    !IMAGE[test-in-context-agent.png](instructions275666/test-in-context-agent.png)

1. In the text box, enter **What can you do?** and submit your message.

    !IMAGE[test-in-context-message.png](instructions275666/test-in-context-message.png)

1. Wait for the response. Notice how the response starts with the text "Thanks for using Teams Toolkit to create your declarative agent!" as defined in the instructions you reviewed earlier.

    !IMAGE[test-in-context-response.png](instructions275666/test-in-context-response.png)

1. To exit the in-context experience, select the cross (X) in the status message. Notice the status message is removed and a message is displayed in the chat window that indicates that you're no longer chatting with the agent.

    !IMAGE[test-in-context-exit.png](instructions275666/test-in-context-exit.png)

    !IMAGE[test-in-context-exit-confirm.png](instructions275666/test-in-context-exit-confirm.png)

Finally, let's test the **immersive** experience.

Continuing in the browser:

1. In **Microsoft 365 Copilot**, select the icon in the top right to expand the Copilot side panel. Notice that the panel displays recent chats and available agents.

    !IMAGE[test-immersive-side-panel.png](instructions275666/test-immersive-side-panel.png)

1. In the side panel, select **Product support** to enter the immersive experience and chat directly with the agent. Notice two sample prompts displayed in the interface.

    !IMAGE[test-immersive.png](instructions275666/test-immersive.png)

1. Select the sample prompt with the title **Learn more**. Notice that the text **What can you do?** is added to the message box for you.

    !IMAGE[test-immersive-learn-more.png](instructions275666/test-immersive-learn-more.png)

1. Send the message and wait for the response. Notice how the response starts with the text "Thanks for using Teams Toolkit to create your declarative agent!" as defined in the instructions you reviewed earlier.

    !IMAGE[test-immersive-response.png](instructions275666/test-immersive-response.png)

Finally, close the browser to stop the debug session in Visual Studio Code.

# Configure custom knowledge

Declarative agents use custom knowledge to provide extra data and context to Microsoft 365 Copilot that is scoped to a specific scenario or task.

Custom knowledge consists of two parts:

- **Custom instructions**: defines how the agent should behave and how it should shape its responses.
- **Custom grounding**: defines the data sources that the agent can use in its responses.

## Update custom instructions

Instructions are specific directives or guidelines that are passed to the foundation model to shape its responses. These instructions can include:

- **Task definitions**: outlining what the model should do, such as answering questions, summarizing text, or generating creative content.
- **Behavioral guidelines**: setting the tone, style, and level of detail for responses to ensure they align with user expectations.
- **Content restrictions**: specifying what the model should avoid, such as sensitive subjects, or copyrighted material.
- **Formatting rules**: showing how the output should be structured, like using bullet points or specific formatting styles.

Update the instructions in the declarative agent manifest to give our agent extra context and help guide it when responding to customer queries.

In Visual Studio Code:

1. Open the **appPackage/instruction.txt** file and update the contents with:

    ```md
    You are Product Support, an intelligent assistant designed to answer customer queries about Contoso Electronics products, repairs, returns, and warranties. You will use documents from Product marketing site as your source of information. If you can't find the necessary information, you should suggest that the agent should reach out to the team responsible for further assistance. Your responses should be concise and always include a cited source.
    ```

1. Save your changes.

## Configure grounding data

Grounding is the process of connecting large language models (LLM) to real-world information, enabling more accurate and relevant responses. Grounding data is used to provide context and support to the LLM when generating responses. It reduces the need for the LLM to rely solely on its training data and improves the quality of the responses.

By default, a declarative agent isn't connected to any data sources. You configure a declarative agent with one or more Microsoft 365 data sources:

- Documents stored in OneDrive
- Documents stored in SharePoint Online
- Content ingested into Microsoft 365 by a Graph connector

In a web browser:

1. Navigate to the Product marketing SharePoint site
1. In the left hand menu, select Documents
1. Examine the documents contents

Configure the Documents document library in the Product marketing SharePoint site as a source of grounding data in the declarative agent manifest.

TODO: CREATE SP SITE WHEN LICENCES ARE ADDED

In Visual Studio Code:

1. In the **appPackage** folder, open **declarativeAgent.json** file.
1. Add the following code snippet to the file, replacing **{URL}** with the direct URL to the **Products** folder in OneDrive that you copied and stored in a text editor earlier:

    ```json
    "capabilities": [
        {
            "name": "OneDriveAndSharePoint",
            "items_by_url": [
                {
                    "url": "https://<tenant>.sharepoint.com/sites/productmarketing/Shared%20Documents"
                }
            ]
        }
    ]
    ```

1. Save your changes.

The **declarativeAgent.json** file should look like this:

```json
{
    "$schema": "https://developer.microsoft.com/json-schemas/copilot/declarative-agent/v1.0/schema.json",
    "version": "v1.0",
    "name": "Product support",
    "description": "Product support agent that can help answer customer queries about Contoso Electronics products",
    "instructions": "$[file('instruction.txt')]",
    "capabilities": [
        {
            "name": "OneDriveAndSharePoint",
            "items_by_url": [
                {
                    "url": "https://<tenant>.sharepoint.com/sites/productmarketing/Shared%20Documents"
                }
            ]
        }
    ]
}
```

## Upload the declarative agent to Microsoft 365

Upload your changes to Microsoft 365 and start a debug session.

In Visual Studio Code:

1. In the **Activity Bar**, open the **Teams Toolkit** extension.
1. In the **Lifecycle** section, select **Provision**.
1. Wait for the upload to complete.
1. In the **Activity Bar**, switch to the **Run and Debug** view.
1. Select the **Start Debugging** button next to the configuration's dropdown, or press <kbd>F5</kbd>. A new browser window is launched and navigates to Microsoft 365 Copilot.

## Test the declarative agent in Microsoft 365 Copilot

Test your declarative agent in Microsoft 365 and validate the results.

First, let's test the instructions:

Continuing in the web browser:

1. In **Microsoft 365 Copilot**, select the icon in the top right to **expand the Copilot side panel**.
1. Find **Product support** in the list of agents and select it to enter the immersive experience to chat directly with the agent.
1. Select the sample prompt with the title **Learn more** and send the message.
1. Wait for the response. Notice how the response is different from the previous instructions and reflects the new instructions.

    !IMAGE[test-custom-instructions.png](instructions275666/test-custom-instructions.png)

Next, let's test the grounding data.

1. In the message box, enter **Tell me about Eagle Air** and send the message.
1. Wait for the response. Notice that the response contains information about the Eagle Air drone. The response contains citations and references to the Eagle Air document stored on the Product marketing SharePoint Online site.

    !IMAGE[test-product-info.png](instructions275666/test-product-info.png)

Let's try a few more prompts:

1. In the message box, enter **Recommend a product suitable for a farmer** and send the message.
1. Wait for the response. Notice that the response contains information about the Eagle Air and some extra context as to why the Eagle Air is recommended. The response contains citations and references to the Eagle Air document stored on the Product marketing SharePoint Online site.

    !IMAGE[test-product-recommendation.png](instructions275666/test-product-recommendation.png)"

1. In the message box, enter **Explain why the Eagle Air is more suitable than Contoso Quad** and send the message.
1. Wait for the response. Notice that the response explains in more detail why the Eagle Air is more suitable than the Contoso Quad for use by farmers.

    !IMAGE[test-product-explanation.png](instructions275666/test-product-explanation.png)

Finally, let's test the fallback response by asking a question that the agent can't answer:

1. In the message box, enter **When was Mark8 released?** and send the message.
1. Wait for the response. Notice that the response suggests that the agent should reach out to the team responsible for further assistance as defined in the instructions.

  !IMAGE[test-fallback.png](instructions275666/test-fallback.png)

Close the browser to stop the debug session in Visual Studio Code.

# Add conversation starters

Conversation starters are sample prompts that are displayed in the immersive experience. These sample prompts provide a quick way for users to understand the types of questions that can be asked.

Update the declarative agent to include conversation starters that provide users with sample prompts to help them understand the types of questions they can ask.

In Visual Studio Code:

1. In the **appPackage** folder, open the **declarativeAgent.json** file.
1. Add the following code snippet to the file:

   ```json
   "conversation_starters": [
       {
           "title": "Product information",
           "text": "Tell me about Eagle Air"
       },
       {
           "title": "Returns policy",
           "text": "What is the returns policy?"
       },
       {
           "title": "Product information",
           "text": "Can you provide information on a specific product?"
       },
       {
           "title": "Product troubleshooting",
           "text": "I'm having trouble with a product. Can you help me troubleshoot the issue?"
       },
       {
           "title": "Repair information",
           "text": "Can you provide information on how to get a product repaired?"
       },
       {
           "title": "Contact support",
           "text": "How can I contact support for help?"
       }
   ],
   ```

1. Save your changes.

The **declarativeAgent.json** file should look like this:

```json
{
  "$schema": "https://developer.microsoft.com/json-schemas/copilot/declarative-agent/v1.0/schema.json",
  "version": "v1.0",
  "name": "Product support",
  "description": "Product support agent that can help answer customer queries about Contoso Electronics products",
  "instructions": "$[file('instruction.txt')]",
  "capabilities": [
    {
      "name": "OneDriveAndSharePoint",
      "items_by_url": [
        {
          "url": "https://<tenant>.sharepoint.com/sites/productmarketing/Shared%20Documents"
        }
      ]
    }
  ],
  "conversation_starters": [
    {
      "title": "Product information",
      "text": "Tell me about Eagle Air"
    },
    {
      "title": "Returns policy",
      "text": "What is the returns policy?"
    },
    {
      "title": "Product information",
      "text": "Can you provide information on a specific product?"
    },
    {
      "title": "Product troubleshooting",
      "text": "I'm having trouble with a product. Can you help me troubleshoot the issue?"
    },
    {
      "title": "Repair information",
      "text": "Can you provide information on how to get a product repaired?"
    },
    {
      "title": "Contact support",
      "text": "How can I contact support for help?"
    }
  ]
}
```

Next, upload your changes and start a debug session.

In Visual Studio Code:

1. In the **Activity Bar**, open the **Teams Toolkit** extension.
1. In the **Lifecycle** section, select **Provision**.
1. Wait for the upload to complete.
1. In the **Activity Bar**, switch to the **Run and Debug** view.
1. Select the **Start Debugging** button next to the configuration's dropdown, or press <kbd>F5</kbd>. A new browser window is launched and navigates to Microsoft 365 Copilot.

Next, test your declarative agent in Microsoft 365 and validate the results.

Continuing in the web browser:

1. In **Microsoft 365 Copilot**, select the icon in the top right to expand the **Copilot side panel**.
1. Find **Product support** in the list of agents and select it to enter the immersive experience to chat directly with the agent. Notice that the conversation starters you defined in the manifest display in the user interface.

!IMAGE[test-conversation-starters.png](instructions275666/test-conversation-starters.png)

# Create a custom engine agent

Custom engine agents are chatbots for Microsoft Teams powered by generative AI, designed to provide sophisticated conversational experiences. Custom engine agents are built using the Teams AI library, which provides comprehensive AI functionalities, including managing prompts, actions, and model integration as well as extensive options for UI customization. This ensures that your chatbots leverage the full range of AI capabilities while delivering a seamless and engaging experience aligned with Microsoft platforms.

## What will we be doing?

Here, you create a custom engine agent that uses a language model hosted in Azure to answer questions using natural language:

- **Create**: Create a custom agent agent project and use Teams Toolkit in Visual Studio.
- **Chat prompts**: Define the system prompt.
- **UI prompts**: Define prompts for starting new conversations.
- **Provision**: Upload your custom engine agent to Microsoft Teams and validate the results.

## Open starter project

TODO: Save the starter project to C:\, you can get the starting code from https://download-directory.github.io/?url=https://github.com/BobGerman/Ignite24-Labs/tree/main/LAB-441/CEA/LAB441-BEGIN

Start with opening the starter project in Visual Studio 2022.

1. Open **Visual Studio 2022**
1. In the Visual Studio 2022 welcome dialog, select **Continue without code**.
1. Open the **File** menu, expand the **Open** menu and select **Project/solution...**.
1. In the Open Project/Solution file picker, on the left hand menu, select **This PC**.
1. Double click **Local Disk (C:)**, then double click **CEA_LAB441-BEGIN** folder.
1. Select **Custom.Engine.Agent.sln**, then select **Open**.

## Examine the solution

The solution contains two projects:

- **Custom.Engine.Agent**: This is an ASP.NET Core Web App which contains your bot code. The bot logic and generative AI capatbilies are implemented using Teams AI library. 
- **TeamsApp**: This is a Teams Toolkit project which contains the app package files, environment, workflow and infrastructure files. You will use this project to provision the required resources for your bot.

## Create dev tunnel

Dev tunnels allow developers to securely share local web services across the internet. When users interact with the bot in Microsoft Teams, the Teams platform will send and recieve messages (called Activities) from your bot code via the Bot Framework. As the code is running on your local machine, the Dev Tunnel exposes the localhost domain which your web app runs on as a publicly accessible URL.

Continue in Visual Studio:

1. Open the **View** menu, expand **Other windows**, and select **Dev Tunnels**.
1. In the **Dev Tunnels** pane, select the **plus (+)** icon.
1. In the dialog window, create the tunnel using the following settings:
    1. **Account**: Select Add an account in the dropdown and follow the sign in for workplace or school account 
    1. **Name**: custom-engine-agent
    1. **Tunnel type**: Temporary
    1. **Access**: Public
1. To create the tunnel, select **OK**.
1. In the confirmation prompt, select **OK**.

## Add Azure AI API Key

To save time we have already provisioned a language model in Azure for you to use in this lab. Teams Toolkit uses environment (.env) files to store values centrally that can be used across your application.

Continue in Visual Studio:

1. In the **TeamsApp** project, expand the **env** folder.
1. Rename the file **.env.local.user.sample** to **.env.local**
1. Open **.env.local.user** file
1. Update the contents of the file:

    ```text
    SECRET_AZURE_OPENAI_API_KEY=[INSERT KEY]
    ```

1. Save the changes.

> [!NOTE]
>  When Teams Toolkit uses an environment variable with that is prefixed with **SECRET**, it will ensure that the value does not appear in any logs. 

# Provision resources

Teams Toolkit help developers automate tasks using workflow files. The workflow files are YML files which are stored in the root of the TeamsApp project.

Continue in Visual Studio:

1. In **TeamsApp** project, open **teamsapp.local.yml**.
1. Examine the contents of the file.

The file contains a single stage called **Provision** which contains several tasks.

1. **teamsApp/create**: Registers an app in Teams Developer Portal and writes the app ID to **env\env.local**.
1. **aadApp/create**: Registers an app in Microsoft Entra and writes several values to **env\env.local**.
1. **aadApp/update**: Applies an app manifest to the Microsoft Entra app registration.
1. **arm/deploy**: Provisions the Azure Bot Service using Bicep. It writes several values back to **env\env.local**.
1. **file/createOrUpdateJsonFile**: Updates appsettings.development.json file in the web app which can be used at runtime.
1. **teamsApp/validateManifest**: Validates the app manifest file.
1. **teamsApp/zipAppPackage**: Creates the Teams app package.
1. **teamsApp/validateAppPackage**: Validates the app package.
1. **teamsApp/update**: Updates the app registration in the Teams Developer Portal.

Use Teams Toolkit to execute the tasks in the workflow file.

1. Right-click **TeamsApp** project.
1. Expand the **Teams Toolkit** menu and select **Prepare Teams App Dependencies**.
1. In the **Microsoft 365 account** dialog, select the account you used to create the Dev Tunnel earlier and select **Continue**. This will start the Dev Tunnel and write the tunnel endpoint and domain to the **env\env.local** file.
1. In the **Provision** dialog, configure the resource group to be used to host the Azure Bot Service:
    1. **Subscription**: Expand the dropdown and select the subscription in the list
    1. **Resource group**: Select **New...**, enter **rg-custom-engine-agent-local** the text field and then select **OK**.
    1. **Region**: East US
    1. Select **Provision**
1. In the warning prompt, select **Provision**.
1. Wait for the process to complete. Teams Toolkit will output its progress in the Output pane.
1. In the **Info** prompt, select **View provisioned resources** to open a browser.

Take a minute to examine the Azure Bot Service resource in the Azure Portal. 

## Run and debug

With everything in place, we are now ready to test our custom engine agent in Microsoft Teams for the first time.

First, we need to start a debug session to start our local web app that contains the bot logic.

Continue in Visual Studio:

1. To start a debug session, press <kbd>F5</kbd> on your keyboard, or select the **Start** button in the toolbar. A browser window is launched and navigates to Microsoft Teams.
1. In the browser, sign in to Microsoft 365 using your Microsoft 365 account details.
1. Wait for Microsoft Teams to load and for the App install dialog to appear.

Previously, Teams Toolkit registered the app in the Teams Developer Portal. To use the app we need to install it for the current user. Teams Toolkit launches the browser using a special URL which enables developers to install the app before they test it.

> [!NOTE]
> If any changes are made to the app manifest file. Developers will need to run the Prepare Teams App dependencies process again and install the app for the changes to be reflected in Microsoft Teams.

Continuing in the web browser:

1. In the App install dialog, select **Add**.
1. In the App install confirmation dialog, select **Open**. The custom engine agent is displayed in Microsoft Teams.

Now let's test that everything is working as expected.

Continuing in the web browser:

1. Enter **Hello, world!** in the message box and press <kbd>Enter</kbd> to send the message to the bot. A typing indicator appears whilst waiting for the  bot to respond.
1. Notice the natural language response from the bot and a label **Generated by AI** is shown in the bot response.
1. Continue a conversation with the bot.
1. Go back to Visual Studio. Notice that in the Debug pane, Teams AI library is tracking the full conversation and displays appended conversation history in the output.
1. Close the browser to stop the debug session.

## Examine bot configuration

The functionality of our bot is implemented using Teams AI library. Let's take a look at how our bot is configured.

In Visual Studio:

1. In the **Custom.Engine.Agent** project, open **Program.cs** file.
1. Examine the contents of the file.

The file sets up the web application and integrates it with Microsoft Bot Framework and services.

- **WebApplicationBuilder**: Initializes web application with controllers and HTTP client services.
- **Configuration**: Retrieve configuration options from the apps configration and sets up Bot Framework authentication.
- **Dependency injection**: Registers BotFrameworkAuthentication and TeamsAdapter services. Configures Azure Blob Storage for persisting bot state and sets up an Azure OpenAI model service.
- **Bot setup**: Registers the bot as a transient service. The bot logic is implemented using Teams AI library.

Let's take a look at the bot setup.

```csharp
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
                return await Task.FromResult(template);
            }
        )
        { LogRepairs = true },
        loggerFactory: loggerFactory
    );

    Application<TurnState> app = new ApplicationBuilder<TurnState>()
        .WithAIOptions(new(planner))
        .WithStorage(sp.GetService<IStorage>())
        .Build();

    return app;
});
```

The key elements of the bot setup are:

- **ILoggerFactory**: Used for logging messages to the output for debugging.
- **PromptManager**: Determines the location of Prompts.
- **ActionPlanner**: Determines which model and prompt should be used when handling a user message. By default, the planner uses a prompt template named 'Chat'.
- **ApplicationBuilder**: Creates an object which represents a Bot that can handle incoming activities.

## Update prompt

Prompts are stored in the Prompts folder. Each prompt consists of two files:

 - **config.json**: Contains the prompt configuration. This enables you to control parameters such as temperature, max tokens etc.
 - **skprompt.txt**: The prompt text template. This text determines the behaviour of the agent.

Let's update the Chat prompt template to change the bot behaviour.

Continuing in Visual Studio:

1. In the **Custom.Engine.Agent** project, expand the **Prompt** folder.
1. In the **Chat** folder, open the **skprompt.txt** file. 
1. Update the contents of the file:

    ```text
    You are a career specialist named "Career Genie" that helps Human Resources team for writing job posts.
    You are friendly and professional.
    You always greet users with excitement and introduce yourself first.
    You like using emojis where appropriate.
    ```

1. Save changes.

Now let's test our change.

1. To start a debug session, press <kbd>F5</kbd> on your keyboard, or select the **Start** button in the toolbar. 
1. Install and open the app in Microsoft Teams.
1. In the message box, enter ++Hi++ and send the message. Wait for the response. Notice the change in the response.
1. In the message box, enter +++Can you help me write a job post for a Senior Developer role?+++ and send the message. Wait for the response.

Continue the conversation by sending more messages.

- +++What would be the list of required skills for a Project Manager role?+++
- +++Can you share a job template?+++

Close the browser to stop the debug session.

## Add UI prompts

Developers can provide starter prompts for users to use. These prompts are shown in the user interface and a good way for users to discover how the bot can help them through examples.

You define UI prompts in the app manifest. The app manifest describes the capabilities of our app. 

Continuing in Visual Studio:

1. In the **TeamsApp** project, expand the **appPackage** folder.
1. In the **appPackage** folder, open the **manifest.json** file.
1. In the **bots** array property, expand the first object with a **commandLists** array property.

    ```
    "bots": [
      {
        "botId": "${{BOT_ID}}",
        "scopes": [
          "personal"
        ],
        "supportsFiles": false,
        "isNotificationOnly": false,
        "commandLists": [
          {
             "scopes": [
               "personal"
             ],
             "commands": [
               {
                 "title": "Write a job post for <role>",
                 "description": "Generate a job posting for a specific role"
               },
               {
                 "title": "Skill required for <role>",
                 "description": "Identify skills required for a specific role"
               }
            ]
          }
        ]
      }
    ],
    ```

Now let's test our change.

As we've made a change to the app manifest file, we need to Run the Prepare Teams App Dependencies process to update the app registration in the Teams Developer Portal.

Continuing in Visual Studio:

1. Right-click **TeamsApp** project, expand the **Teams Toolkit** menu and select **Prepare Teams App Dependencies**.
1. Confirm the prompts and wait till the process completes.
1. Start a debug session, press <kbd>F5</kbd> on your keyboard, or select the **Start** button in the toolbar. 
1. Install and open the app in Microsoft Teams.
1. Above the message box, select **View prompts** to open the prompt suggestions flyout.
1. In the **Prompts** dialog, select one of the prompts. The text is added into the message box.
1. In the message box, replace **<role>** with a job title, for example, Senior Software Engineer, and send the message.

The UI prompts can also be seen when the user opens the bot for the first time.

Continuing in the web browser:

1. In the Microsoft Teams side bar, go to **Chats**.
1. Find the chat with the name **Custom Engine Agent** in the list and select the **...** menu.
1. Select **Delete** and confirm the action.
1. In the Microsoft Teams side bar, select **...** to open the apps flyout.
1. Select **Custom Engine Agent** to start a new chat. The two UI prompts are shown in the user interface.



Close the browser to stop the debug session in Visual Studio Code.
