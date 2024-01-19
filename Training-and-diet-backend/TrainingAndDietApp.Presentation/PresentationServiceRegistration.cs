using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Training_and_diet_backend.Middlewares;
using TrainingAndDietApp.Application.CQRS.Queries.Meal.GetAll;
using TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll;
using TrainingAndDietApp.Application.CQRS.Validators;

namespace Training_and_diet_backend;

public static class PresentationServiceRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureAuthentication(configuration);
        services.AddScoped<ErrorHandlingMiddleware>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetMealsHandler)));
        services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserQueryValidator>());
        services.AddScoped<IValidator<UserQuery>, UserQueryValidator>();
        return services;
    }
    private static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey"])),
                ValidateIssuer = true,
                ValidIssuer = "https://localhost:5001",
                ValidateAudience = true,
                ValidAudience = "https://localhost:5001",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
}