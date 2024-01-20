using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllGymsAdmin;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAllExercicesAdmin
{
    public class GetAllExercisesAdminQueryHandler : IRequestHandler<GetAllExercisesAdminQuery, List<ExerciseNameResponse>>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        public GetAllExercisesAdminQueryHandler(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }
        public async Task<List<ExerciseNameResponse>> Handle(GetAllExercisesAdminQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepository.GetAdminExercisesAsync(cancellationToken);

            return exercises is null
                ? throw new NotFoundException("Exercises not found")
                : _mapper.Map<List<ExerciseNameResponse>>(exercises);
        }
    }
}
