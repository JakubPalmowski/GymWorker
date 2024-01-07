using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.DAL.Models;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IMealRepository
    {
        Task<List<Meal>> GetMealsAsync(CancellationToken cancellationToken);
        Task<Meal?> GetMealByIdAsync(int mealId, CancellationToken cancellationToken);
        Task<List<Meal>> GetMealsByDieticianIdAsync(int dieticianId, CancellationToken cancellationToken);
        Task<int> AddMealAsync(Meal meal, CancellationToken cancellationToken);
        Task<int> DeleteMealAsync(int mealId, CancellationToken cancellationToken);
        Task<int> UpdateMealAsync(Meal meal, CancellationToken cancellationToken);


    }
}
