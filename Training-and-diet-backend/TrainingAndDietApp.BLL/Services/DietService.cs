using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.EntityModels;

namespace Training_and_diet_backend.Services
{
    public interface IDietService
    {
        Task<List<DietEntity>> GetDiets();
    }
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;

        public DietService(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }

        public async Task<List<DietEntity>> GetDiets()
        {
            var diets = await _dietRepository.GetDietsAsync();
            if (diets.Count == 0)
                throw new NotFoundException("There is no diets in database");

            return diets;
        }
    }
}