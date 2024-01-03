using AutoMapper;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Models;

namespace TrainingAndDietApp.BLL.Services
{
    public interface IMealService
    {
        Task<List<MealEntity>> GetMeals();
        Task<MealEntity?> GetMealById(int mealId);
        Task<List<MealEntity>> GetMealsByDieticianId(int dieticianId);
        Task<int> CreateMeal(MealEntity mealEntity);
    }
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
       

        public MealService(IMealRepository mealRepository, IMapper mapper, IUserService userService)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
            _userService = userService;
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
            var meal = await _mealRepository.GetMealByIdAsync(mealId);

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
            if (!await _userService.UserExists(mealEntity.IdDietician))
                throw new NotFoundException("User does not exist");

            if (!await _userService.UserIsDietician(mealEntity.IdDietician))
                throw new BadRequestException("User is not a dietician");

            var meal = _mapper.Map<Meal>(mealEntity);

            return await _mealRepository.AddMealAsync(meal);
        }
    }
}
