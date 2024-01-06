﻿using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.DAL.Repositories
{
   
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            var exercises =  await _context.Exercises.ToListAsync();
            if (!exercises.Any())
                throw new NotFoundException("Exercises not found");
            return exercises;
        }

        public async Task<Exercise?> GetExerciseByIdAsync(int exerciseId, CancellationToken cancellationToken)
        {
            var exercise =  await _context.Exercises
                .Where(e => e.IdExercise == exerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (exercise == null)
                throw new NotFoundException("Exercise not found");

            return exercise;
        }

        public async Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellation)
        {
            var exercises = await _context.Trainee_exercises
                .Where(e => e.IdTrainingPlan == idTrainingPlan)
                .Select(e => e.IdExercise)
                .ToListAsync(cancellationToken: cancellation);

            var exercisesFromTrainingPlan =  await _context.Exercises
                .Where(e => exercises.Contains(e.IdExercise))
                .ToListAsync(cancellationToken: cancellation);

            return exercisesFromTrainingPlan;

        }

        public async Task<int> CreateExerciseAsync(Exercise exercise, CancellationToken cancellation)
        {

            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync(cancellation);
            return exercise.IdExercise;
        }

        public async Task<int> UpdateExerciseAsync(Exercise exercise, CancellationToken cancellation)
        {
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync(cancellation);
            return exercise.IdExercise;
        }

        public async Task<List<Exercise>> GetTrainerExercisesAsync(int trainerId)
        {
            var exercises =  await _context.Exercises.Where(e => e.IdTrainer == trainerId).ToListAsync();

            if (!exercises.Any())
                throw new NotFoundException("Exercises not found");

            return exercises;
        }

        public async Task<int> DeleteExerciseAsync(int exerciseId, CancellationToken cancellation)
        {
            var exercise = await _context.Exercises
                .Where(exercise => exercise.IdExercise == exerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellation);

            if (exercise == null)
                throw new NotFoundException("Exercise not found");

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync(cancellation);
            return exercise.IdExercise;
        }

        public async Task<bool> CheckIfExerciseExists(int exerciseId)
        {
            var exercise = await _context.Exercises
                .Where(exercise => exercise.IdExercise== exerciseId)
                .ToListAsync();

            return exercise.Any();
        }
    }
}
