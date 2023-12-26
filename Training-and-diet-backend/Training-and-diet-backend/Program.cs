using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Controllers;
using Training_and_diet_backend.Middlewares;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using Training_and_diet_backend.Services;
using Training_and_diet_backend.Services.Interfaces;
using Training_and_diet_backend.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TestConnection"));
});
builder.Services.AddScoped<IExerciseService,ExerciseService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ITrainingPlanService,TrainingPlanService>();
builder.Services.AddScoped<IDietService, DietService>();
builder.Services.AddScoped<IMealService,MealService>();
builder.Services.AddScoped<ITraineeExercisesService, TraineeExercisesService>();
builder.Services.AddScoped<IGymRepository, GymRepository>();
builder.Services.AddScoped<IGymService, GymService>();
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
