using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Exercise.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateInternalExerciseCommand, ExerciseNameResponse>
    {
        private readonly IRepository<Domain.Entities.Exercise> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateExerciseCommandHandler(IMapper mapper, IRepository<Domain.Entities.Exercise> repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ExerciseNameResponse> Handle(CreateInternalExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = _mapper.Map<Domain.Entities.Exercise>(request);
            await _repository.AddAsync(exercise, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<ExerciseNameResponse>(exercise);
        }

    }
}