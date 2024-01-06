using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface ITraineeExercisesRepository
    {
        Task<int> AddTraineeExercisesAsync(TraineeExercise traineeExercise);
    }
}
