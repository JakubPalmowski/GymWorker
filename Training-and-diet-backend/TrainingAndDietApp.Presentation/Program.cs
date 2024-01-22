using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Training_and_diet_backend;
using Training_and_diet_backend.Middlewares;
using TrainingAndDietApp.Application;
using TrainingAndDietApp.Infrastructure;
using TrainingAndDietApp.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddApiServices(builder.Configuration);


var keyVaultURL = builder.Configuration.GetSection("KeyVault:KeyVaultURL");
var keyVaultClientId = builder.Configuration.GetSection("KeyVault:ClientId");
var keyVaultClientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret");
var keyVaultDirectoryId = builder.Configuration.GetSection("KeyVault:DirectoryID");

var credential = new ClientSecretCredential(keyVaultDirectoryId.Value!, keyVaultClientId.Value!, keyVaultClientSecret.Value!);

builder.Configuration.AddAzureKeyVault(keyVaultURL.Value!, keyVaultClientId.Value!,keyVaultClientSecret.Value!, new DefaultKeyVaultSecretManager());

var client = new SecretClient(new Uri(keyVaultURL.Value!), credential);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(client.GetSecret("ConnectionStrings--TestConnection").Value.Value);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
