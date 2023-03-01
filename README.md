# Multitenant application using Azure Cosmos DB in Clean Architecture
A starting point to build a multi-tenant web API to work with Azure Cosmos DB, based on Clean Architecture and repository design pattern. Partition key is also implemented through the repository pattern. 

**Tech stack**
* .NET 6
* Azure Cosmos DB .NET SDK V3

# Getting Started - API
1. Download the Azure CosmosDB emulator: https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator-release-notes#download.
2. Start the emulator locally
3. Set the API project as your Startup project in Visual Studio and run the web API
4. The swagger UI page should be loaded at: https://localhost:5001/swagger/index.html
5. Running the API project will automatically ensure Cosmos DB database and containers are created and also seed application data. See Program.cs

# Give a star
:star: If you enjoy this project, or are using this project to start your exciting new project, or are just forking it to play, please give it a star. Much appreciated! :star: 
