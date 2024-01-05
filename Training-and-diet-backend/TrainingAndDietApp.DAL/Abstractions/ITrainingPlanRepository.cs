using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.DAL.Models;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface ITrainingPlanRepository
    {
        Task<int> AddTrainingPlanAsync(TrainingPlan trainingPlan);
        Task<TrainingPlan?> GetTrainingPlanByIdAsync(int trainingPlanId);

        Task<bool> CheckIfTrainingPlanExists(int trainingPlanId);
    }
}
