using System.Collections.Generic;
using TrainingAndDietApp.Domain.Entities;



namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IDietRepository
    {
        public Task<List<Diet>> GetDieticianDietsAsync(int dieticianId, CancellationToken cancellationToken);
        public Task<List<Diet>> GetPupilDietsAsync(int pupilId, CancellationToken cancellationToken);
        public Task<Diet?> GetMentorDietAsync(int dietId, CancellationToken cancellationToken);
        public Task<Diet?> GetPupilDietAsync(int dietId, CancellationToken cancellationToken);
    }
}
