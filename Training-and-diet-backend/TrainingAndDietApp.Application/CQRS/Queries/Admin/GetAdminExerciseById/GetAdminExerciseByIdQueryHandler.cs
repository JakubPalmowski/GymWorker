using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetAdminExerciseById
{
    public class GetAdminExerciseByIdQueryHandler : IRequestHandler<GetAdminExerciseByIdQuery, ExerciseResponse>
    {
        private readonly IRepository<Domain.Entities.Exercise> _exerciseBaseRepository;
        private readonly IMapper _mapper;

        public GetAdminExerciseByIdQueryHandler(IRepository<Domain.Entities.Exercise> exerciseBaseRepository, IMapper mapper)
        {
            _exerciseBaseRepository = exerciseBaseRepository;
            _mapper = mapper;

        }
        public async Task<ExerciseResponse> Handle(GetAdminExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseBaseRepository.GetByIdAsync(request.IdExercise, cancellationToken);
            if (exercise == null || exercise.IdTrainer != null)
                throw new NotFoundException("Exercise not found");
            
            var response = _mapper.Map<ExerciseResponse>(exercise);
            return response;
            
        }
    }
}
