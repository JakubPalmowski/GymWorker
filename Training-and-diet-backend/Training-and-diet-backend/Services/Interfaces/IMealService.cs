using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services.Interfaces
{
    public interface IMealService
    {
        Task<List<Meal>> GetMeals();
    }
}
