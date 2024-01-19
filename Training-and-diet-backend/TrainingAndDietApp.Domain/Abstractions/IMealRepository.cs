using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IMealRepository
    {
        Task<List<Meal>> GetMealsByDieticianIdAsync(int dieticianId, CancellationToken cancellationToken);


    }
}
