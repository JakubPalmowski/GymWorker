using AutoMapper;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.Exceptions;

namespace Training_and_diet_backend.Services
{
    public interface IDietService
    {
        Task<List<DietEntity>> GetDiets();
    }
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public DietService(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }

        public async Task<List<DietEntity>> GetDiets()
        {
            var diets = await _dietRepository.GetDietsAsync();
            if (diets.Count == 0)
                throw new NotFoundException("There is no diets in database");

            return _mapper.Map<List<DietEntity>>(diets);
        }
    }
}