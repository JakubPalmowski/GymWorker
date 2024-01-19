using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface ITrainingPlanRepository
    {
        Task<List<TrainingPlan>> GetTrainerTrainingPlans(int idTrainer, CancellationToken cancellationToken);
        Task<bool> CheckIfTrainingPlanExists(int trainingPlanId, CancellationToken cancellationToken);

    }
}
