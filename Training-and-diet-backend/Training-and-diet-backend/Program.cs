using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Middlewares;
using Training_and_diet_backend.Repositories;
using Training_and_diet_backend.Services;
using Training_and_diet_backend.Validators;
using TrainingAndDietApp.Application.Handlers.Meal;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.DAL.Repositories;
using TrainingAndDietApp.Domain.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TestConnection"));
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetMealsHandler)));
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseRepository,ExerciseRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITrainingPlanService, TrainingPlanService>();
builder.Services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
builder.Services.AddScoped<IDietService, DietService>();
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IMealService,MealService>();
builder.Services.AddScoped<IMealRepository,MealRepository>();
builder.Services.AddScoped<ITraineeExercisesService, TraineeExercisesService>();
builder.Services.AddScoped<ITraineeExercisesRepository, TraineeExercisesRepository>();
builder.Services.AddScoped<IGymService, GymService>();
builder.Services.AddScoped<IGymRepository, GymRepository>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IValidator<UserQuery>,UserQueryValidator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services
    .AddControllers()
    .AddFluentValidation(fv => {
        fv.RegisterValidatorsFromAssemblyContaining<UserQueryValidator>();
    });

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
