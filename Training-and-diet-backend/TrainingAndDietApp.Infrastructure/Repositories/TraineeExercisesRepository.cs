﻿using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{
    
    public class TraineeExercisesRepository : ITraineeExercisesRepository
    {
        private readonly ApplicationDbContext _context;

        public TraineeExercisesRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<TraineeExercise?> GetTrainerTraineeExerciseWithExerciseByIdAsync(int idTraineeExercise, int idTrainer,
            CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises
                .Where(e => e.IdTraineeExercise == idTraineeExercise && e.TrainingPlan.IdTrainer == idTrainer)
                .Include(e => e.Exercise)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
        public async Task<TraineeExercise?> GetPupilTraineeExerciseWithExerciseByIdAsync(int idTraineeExercise, int idPupil,
            CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises
                .Where(e => e.IdTraineeExercise == idTraineeExercise && e.TrainingPlan.IdPupil == idPupil)
                .Include(e => e.Exercise)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<TraineeExercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises
                .Where(te => te.IdTrainingPlan == idTrainingPlan)
                .Include(te => te.Exercise)
                .ToListAsync(cancellationToken);
            
        }

        public async Task<TraineeExercise?> GetTraineeExerciseWithTrainingPlanAndTrainerByIdAsync(int idTrainingPlan, CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises.Where(te => te.IdTrainingPlan == idTrainingPlan)
                .Include(te => te.TrainingPlan)
                .ThenInclude(tp => tp.Trainer)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TraineeExercise?> GetTraineeExerciseWithTrainingPlanAndPupilByIdAsync(int idTrainingPlan, CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises.Where(te => te.IdTrainingPlan == idTrainingPlan)
                .Include(te => te.TrainingPlan)
                .ThenInclude(tp => tp.Pupil)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
