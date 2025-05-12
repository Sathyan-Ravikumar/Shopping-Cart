
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using UserModule.Modal.DataAccess;
using UserModule.Repository.Repositories;
using UserModule.Repository.Repository_Interfaces;
using UserModule.Services.Service_Interfaces;
using UserModule.Services.Services;
using UserModule.ViewModal.RequestModal.Mapper.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<SqlServerConnection>();
builder.Services.AddAutoMapper(typeof(MapperClass));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStoredProcedures, StoredProcedures>();
builder.Services.AddScoped<IUserRegister, UserRegister>();
builder.Services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

var keyVaultUrl = builder.Configuration["KeyVault:KeyVaultURL"];
var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

var dbConnection = secretClient.GetSecret("SQLConnection").Value.Value;
var accountSid = secretClient.GetSecret("Twilio-AccountSid").Value.Value;
var authToken = secretClient.GetSecret("Twilio-AuthToken").Value.Value;
var fromPhone = secretClient.GetSecret("Twilio-FromPhone").Value.Value;
var tokenKey = secretClient.GetSecret("JWT-TokenKey").Value.Value;
var emailHost = secretClient.GetSecret("EmailHost").Value.Value;
var emailPassword = secretClient.GetSecret("EmailPassword").Value.Value;
var emailUserName = secretClient.GetSecret("EmailUsername").Value.Value;

// inject values retrieved from Azure Key Vault into the application's configuration at runtime. 
builder.Configuration["ConnectionStrings:SQLConnection"] = dbConnection;
builder.Configuration["Twilio:AccountSid"] = accountSid;
builder.Configuration["Twilio:AuthToken"] = authToken;
builder.Configuration["Twilio:FromPhone"] = fromPhone;
builder.Configuration["Jwt:TokenKey"] = tokenKey;
builder.Configuration["EmailHost"] = emailHost;
builder.Configuration["EmailUsername"] = emailUserName;
builder.Configuration["EmailPassword"] = emailPassword;


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
