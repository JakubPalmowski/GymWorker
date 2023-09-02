using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Controllers
{
    public interface IUserService
    {
        IQueryable<User> GetPupilsByTrainerId(int TrainderId);
    }
}
