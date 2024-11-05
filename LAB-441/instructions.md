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

Close the browser to stop the debug session in Visual Studio Code.
