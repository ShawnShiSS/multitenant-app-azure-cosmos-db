using Infrastructure.Persistence.CosmosDb.Extensions;
using WebAPI.Config;

IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true,
                    true)
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Cosmos DB for application data
builder.Services.SetupCosmosDb(configuration);

// API controllers
builder.Services.AddControllers();

// Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    // Ensure Cosmos DB is created and optionally seeded.
    app.EnsureCosmosDbIsCreated().Wait();
    app.SeedDataContainerIfEmptyAsync().Wait();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
