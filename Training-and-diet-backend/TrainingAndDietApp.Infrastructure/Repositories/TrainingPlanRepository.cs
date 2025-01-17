﻿using Microsoft.EntityFrameworkCore;
using Npgsql.PostgresTypes;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{
    

    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TrainingPlan>> GetTrainerTrainingPlans(int idTrainer, CancellationToken cancellationToken)
        {
            return await  _context.Training_plans.Where(e => e.IdTrainer == idTrainer).ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<TrainingPlan?> GetByIdWithPupil(int trainingPlanId, CancellationToken cancellationToken)
        {
            return await _context.Training_plans.Include(plan => plan.Pupil)
                .Where(plan => plan.IdTrainingPlan == trainingPlanId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<TrainingPlan?> GetByIdWithTrainer(int trainingPlanId, CancellationToken cancellationToken)
        {
            return await _context.Training_plans.Include(plan => plan.Trainer)
                .Where(plan => plan.IdTrainingPlan == trainingPlanId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<bool> CheckIfTrainingPlanExists(int trainingPlanId, CancellationToken cancellationToken)
        {
            var trainingPlan = await _context.Training_plans
                .Where(plan => plan.IdTrainingPlan == trainingPlanId)
                .ToListAsync(cancellationToken: cancellationToken);

            return trainingPlan.Any();
        }

        public async Task<List<TrainingPlan>> GetTrainingPlansWithTrainerByPupilId(int idPupil, CancellationToken cancellationToken)
        {
            return await _context.Training_plans.Include(plan => plan.Trainer)
                .Where(plan => plan.IdPupil == idPupil)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
