using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Controllers
{
    public interface IUserService
    {
        Task<IQueryable<User>> GetPupilsByTrainerId(int TrainderId);
        Task<List<Exercise>> GetTrainerExercises(int TrainderId);
        public Task<List<Training_plan>> GetTrainerTrainingPlans(int id_trainer);
    }
}
