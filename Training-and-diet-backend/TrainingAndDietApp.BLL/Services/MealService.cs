using AutoMapper;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.BLL.Services
{
    public interface IMealService
    {
        Task<List<MealEntity>> GetMeals();
        Task<MealEntity?> GetMealById(int mealId);
        Task<List<MealEntity>> GetMealsByDieticianId(int dieticianId);
        Task<int> CreateMeal(MealEntity mealEntity);
        Task<int> DeleteMeal(int mealId);
        Task<int> UpdateMeal(MealEntity mealEntity, int mealId);
    }
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IUserServiceDeprecated _userServiceDeprecated;
        private readonly IMapper _mapper;
       

        public MealService(IMealRepository mealRepository, IMapper mapper, IUserServiceDeprecated userServiceDeprecated)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
            _userServiceDeprecated = userServiceDeprecated;
        }

        public async Task<List<MealEntity>> GetMeals()
        {
            var mealEntities = await _mealRepository.GetMealsAsync();
            if (mealEntities.Count == 0)
                throw new NotFoundException("No meals found");

            
            return _mapper.Map<List<MealEntity>>(mealEntities);


        }
        public async Task<MealEntity?> GetMealById(int mealId)
        {
            var meal = await _mealRepository.GetMealByIdAsync(mealId, CancellationToken.None);

            if (meal == null)
                throw new NotFoundException("Meal not found");

            return _mapper.Map<MealEntity>(meal);
        }

        public async Task<List<MealEntity>> GetMealsByDieticianId(int dieticianId)
        {
            var mealsFromDb = await _mealRepository.GetMealsByDieticianIdAsync(dieticianId);

            if (!mealsFromDb.Any())
                throw new NotFoundException("Meals not found");

            return _mapper.Map<List<MealEntity>>(mealsFromDb);

            
        }
       
        public async Task<int> CreateMeal(MealEntity mealEntity)
        {
            if (!await _userServiceDeprecated.UserExists(mealEntity.IdDietician))
                throw new NotFoundException("User does not exist");

            if (!await _userServiceDeprecated.UserIsDietician(mealEntity.IdDietician))
                throw new BadRequestException("User is not a dietician");

            var meal = _mapper.Map<Meal>(mealEntity);

            return await _mealRepository.AddMealAsync(meal, CancellationToken.None);
        }

        public async Task<int> DeleteMeal(int mealId)
        {
            return await _mealRepository.DeleteMealAsync(mealId, CancellationToken.None);
        }

        public async Task<int> UpdateMeal(MealEntity mealEntity, int mealId)
        {
            if (!await _userServiceDeprecated.UserExists(mealEntity.IdDietician))
                throw new NotFoundException("User does not exist");

            if (!await _userServiceDeprecated.UserIsDietician(mealEntity.IdDietician))
                throw new BadRequestException("User is not a dietician");
            var meal = await _mealRepository.GetMealByIdAsync(mealId, CancellationToken.None);

            _mapper.Map(mealEntity, meal);
            await _mealRepository.UpdateMealAsync(meal, CancellationToken.None);
            return mealId;
        }
    }
}
