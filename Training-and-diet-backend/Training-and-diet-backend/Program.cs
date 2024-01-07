using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Middlewares;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Handlers.Meal;
using TrainingAndDietApp.Application.Services;
using TrainingAndDietApp.Application.Validators;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.Repositories;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Infrastructure.Repositories;
using UserQuery = TrainingAndDietApp.Application.Queries.User.UserQuery;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TestConnection"));
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetMealsHandler)));
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<ITraineeExerciseService, TraineeExerciseService>();
builder.Services.AddScoped<ITraineeExercisesRepository, TraineeExercisesRepository>();
builder.Services.AddScoped<IGymRepository, GymRepository>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IValidator<UserQuery>, TrainingAndDietApp.Application.Validators.UserQueryValidator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserQueryValidator>());




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
