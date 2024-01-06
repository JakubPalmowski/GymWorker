﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface ITrainingPlanRepository
    {
        Task<int> AddTrainingPlanAsync(TrainingPlan trainingPlan, CancellationToken cancellationToken);
        Task<TrainingPlan?> GetTrainingPlanByIdAsync(int trainingPlanId, CancellationToken cancellationToken);

        Task<bool> CheckIfTrainingPlanExists(int trainingPlanId);
    }
}
