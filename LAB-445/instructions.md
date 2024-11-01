# Lab 445 - Build Declarative Agents for Microsoft 365 Copilot

In this lab you will build a declarative agent that assists employees of a fictitous consulting company called Trey Research. Like all declarative agents, this will use the AI models and orchestration that's built into Microsoft 365 to provide a specialized Copilot experience that focuses on information about consultants, billing, and projects.

To make it easier, we will begin with a working declarative agent and API plugin. These are similar to what you'd get in a new project generated with Teams Toolkit, however there is a working database and sample data to work with.

The starting solution begins with access to data about consultants, but lacks general information about projects. At best it can find information about projects assigned to consultants, not projects on their own.

In the exercises that follow, you will:

 - Instruct the declarative agent on how to interact with users
 - Add a reference to a SharePoint site containing project documents
 - Add a /projects feature to the API plugin; this will show you all of the relevant packaging files needed to make the API plugin work without asking you to build the whole thing in the limited time of this lab

 ## Exercise 1: Run the starting solution

 ### Step 1: Open the solution in Visual Studio Code with Teams Toolkit

 The starting solution is already in your lab virtual machine at %START_LOCATION%.
 Open Visual Studio Code and under the "File" menu, select "Open folder" and navigate to %START_LOCATION%.

 Open the Teams Toolkit tab on the left 1️⃣ and under "Accounts", click "Sign in to Microsoft 365" 2️⃣.

 ![Sign into Teams Toolkit](./images/01-04-Setup-TTK-01.png)

 Ensure that the "Custom app upload enabled" and "Copilot access enabled" checkboxes are checked (it takes a moment) before proceeding.

 ![Check services are enabled](./images/run-in-ttk01.png)

### Step 2: Set up the local environment files

Copy the **/env/.env.local.user** sample to **/env/.env.local.user**. If **.env.local.user** already exists, ensure this line is present:

~~~text
SECRET_STORAGE_ACCOUNT_CONNECTION_STRING=UseDevelopmentStorage=true
~~~

### Step 2: Run the solution

Press F5 or hover over the "local" environment and click the debugger symbol that will be displayed 1️⃣ and then select "debug in Microsft Edge" 2️⃣.

![Start debugger](./images/run-in-ttk02.png)

It will take a while. If you get an error ??? (can't run script) -- HAVE THEM TRY AGAIN -- NEED TO REPRO FOR DETAILS





 SHAREPOINT_DOCS_URL=https://m365cpi84406958.sharepoint.com/sites/LegalDocuments