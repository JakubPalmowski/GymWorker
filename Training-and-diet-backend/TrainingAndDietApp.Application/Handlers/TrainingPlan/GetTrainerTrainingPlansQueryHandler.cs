using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.TrainingPlan;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.TrainingPlan;

public class GetTrainerTrainingPlansQueryHandler : IRequestHandler<GetTrainerTrainingPlansQuery, IEnumerable<GetTrainerTrainingPlansResponse>>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetTrainerTrainingPlansQueryHandler(IMapper mapper, ITrainingPlanRepository trainingPlanRepository, IUserService userService)
    {
        _mapper = mapper;
        _trainingPlanRepository = trainingPlanRepository;
        _userService = userService;
    }
    public async Task<IEnumerable<GetTrainerTrainingPlansResponse>> Handle(GetTrainerTrainingPlansQuery request, CancellationToken cancellationToken)
    {
        if(! await _userService.CheckIfUserExists(request.IdTrainer, cancellationToken))
            throw new NotFoundException("User not found");
        if(! await _userService.CheckIfUserIsTrainer(request.IdTrainer, cancellationToken))
            throw new BadRequestException("User is not a trainer");


        var trainingPlans = await _trainingPlanRepository.GetTrainerTrainingPlans(request.IdTrainer, cancellationToken);
        if(trainingPlans == null)
            throw new NotFoundException("Trainer has no training plans");

        return _mapper.Map<List<GetTrainerTrainingPlansResponse>>(trainingPlans);

    }
}