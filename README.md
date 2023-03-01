# Multitenant application using Azure Cosmos DB in Clean Architecture
A starting point to build a multi-tenant web API to work with Azure Cosmos DB, based on Clean Architecture and repository design pattern. Partition key is also implemented through the repository pattern. Azure Cosmos DB .NET SDK V3 and .NET 6 are used.

# Getting Started - API
1. Download the [Azure CosmosDB emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=ssl-netstd21)
2. Start the emulator locally
3. Set the API project as your Startup project in Visual Studio and run the web API
4. The swagger UI page should be loaded at: https://localhost:5001/swagger/index.html
5. Running the API project will automatically ensure Cosmos DB database and containers are created and also seed application data. See Program.cs

# Give a star
:star: If you enjoy this project, or are using this project to start your exciting new project, or are just forking it to play, please give it a star. Much appreciated! :star: 

# Features supported
* .NET 6
* Azure Cosmos DB .NET SDK V3
* Partition key per tenant implementation
* Partitioned repository pattern
* Clean Architecture
* REST API

# Additional Resources
I have published some short articles to cover different aspects of this project. Please feel free to give them a read.
* [Understanding Multitenancy Isolation Models in Plain English](https://medium.com/geekculture/understanding-multitenancy-isolation-models-in-plain-english-c296b100035e)
