using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Controllers
{
    public interface IUserService
    {
        public Task<List<User>> GetPupilsByTrainerId(int id_trainer);
        Task<List<Exercise>> GetTrainerExercises(int TrainderId);
        public Task<List<GetTrainingPlanGeneralInfoDTO>> GetTrainerTrainingPlans(int id_trainer);

        Task<List<GetExercisesByTrainerIdDTO>> GetExercisesByTrainerId(int id_trainer);
        public Task<List<GetUsersDTO>> GetUsers(string roleName);
        public Task<GetUserWithOpinionsByIdDTO> GetUsersWithOpinionsById(string roleName,int id);
    }
}
