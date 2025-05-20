using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using products.Application.Services;
using products.Application.Services_Interface;
using Products.Domain.Repositories;
using Products.Domain.RepositoryInterfaces;
using Products.Modal.DataAccess;
using Products.View_Request_Modals.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SqlServerConnection>();
builder.Services.AddAutoMapper(typeof(MapperClass));
builder.Services.AddScoped<IStoredProcedures, StoredProcedures>();
builder.Services.AddScoped<IBrands, BrandsRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IProductReviewRepository,ProductReviewsRepository>();
builder.Services.AddScoped<IProductReviewService, ProductReviewService>();
builder.Services.AddScoped<IBlobService, BlobService>();

var app = builder.Build();

var keyVaultUrl = builder.Configuration["KeyVault:KeyVaultURL"];
var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

var dbConnection = secretClient.GetSecret("SQLConnection").Value.Value;
var storageAccountConnectionString = secretClient.GetSecret("StorageAccountConnectionString").Value.Value;
var storageAccountContainerName = secretClient.GetSecret("StorageAccountContainerName").Value.Value;

builder.Configuration["ConnectionStrings:SQLConnection"] = dbConnection;
builder.Configuration["StorageAccount:ConnectionString"] = storageAccountConnectionString;
builder.Configuration["StorageAccount:ContainerName"] = storageAccountContainerName;

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
