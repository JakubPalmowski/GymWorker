using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
   
    public interface IMealDietRepository
    {
        public Task<List<MealDiet>> GetMealsByDietIdAsync(int dietId, CancellationToken cancellationToken);
        public Task<MealDiet?> GetMealDietByIdAsync(int idMealDiet, CancellationToken cancellationToken);
    }
}