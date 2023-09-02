using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Controllers;
using Training_and_diet_backend.Services;

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
