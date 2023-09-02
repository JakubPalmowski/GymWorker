using Training_and_diet_backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_and_diet_backend.DTOs;

namespace Training_and_diet_backend.Services
{
    public interface IExerciseService
    {
        IQueryable<Exercise> GetExerciseById(int ExerciseId);
        Task<List<GetAllExercisesDTO>> GetAllExercises();
    }
}
