# NewsPortalApp

This is a news portal application with basic CRUD option, Authentication and Authorization, Unit-tests etc. 
It's backend soultion uses custom REST API for all requests using .NET Core (C#) and Entity framework Core for working with the database where I used DATABASE FIRST principle.
It's front-end solution is done in Angular using some of the Bootstrap template parts.

## Getting Started

SoftraySolution.bak file is for restoring the database directly in Microsoft SQL Server, it contains all data needed for this application to work.
Be sure to do this so you can get Account credentials, since the app doesn't have Registration options yet.

### Prerequisites

You will need:

Microsoft SQL Server Management Studio 2019 to run the scripts.

Visual Studio 2019 to run the application.

Vistual Studio Code if you want to use it as an editor, like I did.

Node.js command prompt

## Running the app

Be sure to open node.js command prompt in administaton mode and navigate to the ClientApp folder of this application.

* Execute this command:
```
npm start
```

This will make your build very fast also.

You have to do this only once when first starting the app, keep the node.js window on.

* Run the app in Visual Studio 2019

```
Ctrl + F5
```

**Now you can test the application on the UI side!** 

**Note:** If you want to test the application calls to api you can use **Swagger** by entering /swagger.html in the url of the app.

### Overall functionalities

This application has two kinds of users. A public user and an Administrator user. 

The public user has the possibility to read and to search for news without any kind of authentication or authorization.

The administrator user has the possibility to perform the same actions as the public user plus he should be able to add news, edit news and he should also has the possibility to view all news he added or edited in a tabular view where he can search for them.


