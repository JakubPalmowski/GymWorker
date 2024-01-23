using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.DeleteExercise
{
    public class DeleteAdminExerciseCommandHandler : IRequestHandler<DeleteAdminExerciseCommand>
    {
        private readonly IRepository<Domain.Entities.Exercise> _exerciseBaseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdminExerciseCommandHandler(IRepository<Domain.Entities.Exercise> exerciseBaseRepository, IUnitOfWork unitOfWork)
        {
            _exerciseBaseRepository = exerciseBaseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAdminExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseBaseRepository.GetByIdAsync(request.IdExercise, cancellationToken);
            if (exercise == null || exercise.IdTrainer != null){
                throw new NotFoundException("Exercise not found");
            }
            await _exerciseBaseRepository.DeleteAsync(exercise.IdExercise, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

    }
}
