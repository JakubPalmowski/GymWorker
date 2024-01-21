using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.CreateExercise
{
    public class CreateExerciseAdminCommandHandler : IRequestHandler<CreateExerciseAdminInternalCommand, ExerciseNameResponse>
    {
        private readonly IRepository<Domain.Entities.Exercise> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateExerciseAdminCommandHandler(IMapper mapper, IRepository<Domain.Entities.Exercise> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ExerciseNameResponse> Handle(CreateExerciseAdminInternalCommand request, CancellationToken cancellationToken)
        {
            var exercise = _mapper.Map<Domain.Entities.Exercise>(request);
            await _repository.AddAsync(exercise, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<ExerciseNameResponse>(exercise);
        }
    }
}
