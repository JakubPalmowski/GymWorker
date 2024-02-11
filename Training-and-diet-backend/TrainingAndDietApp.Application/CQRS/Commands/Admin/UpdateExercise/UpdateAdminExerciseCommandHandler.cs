using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateExercise
{
    public class UpdateAdminExerciseCommandHandler : IRequestHandler<UpdateAdminExerciseInternalCommand>
    {
        private readonly IRepository<Domain.Entities.Exercise> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    public UpdateAdminExerciseCommandHandler(IMapper mapper, IRepository<Domain.Entities.Exercise> repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
        public async Task Handle(UpdateAdminExerciseInternalCommand request, CancellationToken cancellationToken)
        {
            var exerciseToUpdate = await _repository.GetByIdAsync(request.IdExercise, cancellationToken);
            if (exerciseToUpdate == null || exerciseToUpdate.IdTrainer != null)
                throw new NotFoundException("Exercise not found");
            
            _mapper.Map(request, exerciseToUpdate);
            await _repository.UpdateAsync(exerciseToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
