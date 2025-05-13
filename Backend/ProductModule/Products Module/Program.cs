using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Products.Domain.Repositories;
using Products.Domain.RepositoryInterfaces;
using Products.Modal.DataAccess;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SqlServerConnection>();
builder.Services.AddScoped<IStoredProcedures, StoredProcedures>();

var app = builder.Build();

var keyVaultUrl = builder.Configuration["KeyVault:KeyVaultURL"];
var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

var dbConnection = secretClient.GetSecret("SQLConnection").Value.Value;

builder.Configuration["ConnectionStrings:SQLConnection"] = dbConnection;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
