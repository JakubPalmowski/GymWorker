using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Infrastructure.Context;
using TrainingAndDietApp.Infrastructure.Persistance;
using TrainingAndDietApp.Infrastructure.Repositories;

namespace TrainingAndDietApp.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IMealRepository, MealRepository>();
        services.AddScoped<ITraineeExercisesRepository, TraineeExercisesRepository>();
        services.AddScoped<IGymRepository, GymRepository>();
        services.AddScoped<ITrainerGymRepository, TrainerGymRepository>();
        services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<IPupilMentorRepository, PupilMentorRepository>();
        services.AddScoped<IOpinionRepository, OpinionRepository>();
        services.AddScoped<IDietRepository, DietRepository>();

        return services;
    }
}