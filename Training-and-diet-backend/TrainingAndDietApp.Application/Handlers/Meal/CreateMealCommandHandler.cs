using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Application.Responses.Meal;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Meal
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, MealResponse>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateMealCommandHandler(IMealRepository mealRepository, IMapper mapper, IUserRepository userRepository)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<MealResponse> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            if (!await CheckIfUserExists(request.IdDietician, cancellationToken))
                throw new NotFoundException("User not found");

            if (!await CheckIfUserIsDietician(request.IdDietician, cancellationToken))
                throw new BadRequestException("User is not a dietician");

            var result = _mapper.Map<DAL.Models.Meal>(request);
            await _mealRepository.AddMealAsync(result, cancellationToken);
            return _mapper.Map<MealResponse>(result);
        }

        private async Task<bool> CheckIfUserIsDietician(int dieticianId, CancellationToken cancellation)
        {
            return await _userRepository
                .AnyAsync(user => user.IdUser == dieticianId && (user.Role.Name.Equals("Dietician") || user.Role.Name.Equals("Dietician-Trainer")));
        }
        private async Task<bool> CheckIfUserExists(int idUser, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(idUser, cancellationToken);
            return user != null;
        }
    }
}
