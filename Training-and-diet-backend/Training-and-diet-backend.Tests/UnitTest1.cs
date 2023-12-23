using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;

namespace Training_and_diet_backend.Tests;
public class ExerciseServiceTests
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ExerciseService _exerciseService;

    public ExerciseServiceTests()
    {
        // Configure in-memory database
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryTestDatabase")
            .Options;
        _context = new ApplicationDbContext(options);

        // Seed the database
        SeedDatabase();

        // Configure AutoMapper
        _mapper = new MapperConfiguration(cfg =>
        {
            // Add your AutoMapper configuration here
            cfg.AddProfile<MappingProfile>(); // Replace with your actual profile
        }).CreateMapper();

        _exerciseService = new ExerciseService(_context, _mapper);
    }

    private void SeedDatabase()
    {
        // Seed your in-memory database with test data
        _context.Exercises.AddRange(
            new Exercise { /* ... */ },
            new Exercise { /* ... */ }
            // Add your test exercises
        );

        _context.SaveChanges();
    }
    [Fact]
    public async Task GetAllExercises_ReturnsAllExercises()
    {
        // Act
        var result = await _exerciseService.GetAllExercises();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Count > 0); // Assuming you have seeded some exercises
    }

    // Dispose method if needed
}

