using System.Collections.Generic;
using TrainingAndDietApp.DAL.EntityModels;


namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IDietRepository
    {
        public Task<List<Diet>> GetDieticianDietsAsync(int dieticianId, CancellationToken cancellationToken);
    }
}
