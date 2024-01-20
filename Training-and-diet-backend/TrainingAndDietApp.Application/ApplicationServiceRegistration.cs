using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Abstractions.Auth;
using TrainingAndDietApp.Application.CQRS.Queries.Meal.GetAll;
using TrainingAndDietApp.Application.CQRS.Validators;
using TrainingAndDietApp.Application.Services;
using TrainingAndDietApp.Application.Services.Auth;
using TrainingAndDietApp.Application.Services.Files;

namespace TrainingAndDietApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserQueryValidator>());
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ITrainingPlanAccessService, TrainingPlanAccessService>();
        services.AddSingleton<IFileService, FileService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetMealsHandler)));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITraineeExerciseService, TraineeExerciseService>();
        return services;
    }
}