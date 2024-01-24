using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Opinion.DeleteOpinion
{
    public class DeleteOpinionCommandHandler : IRequestHandler<DeleteOpinionCommand>
    {
        private readonly IOpinionRepository _opinionRepository;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteOpinionCommandHandler(IOpinionRepository opinionRepository, IUnitOfWork unitOfWork)
        {
            _opinionRepository = opinionRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task Handle(DeleteOpinionCommand request, CancellationToken cancellationToken)
        {
            var opinion = await _opinionRepository.GetPupilMentorOpinionAsync(request.IdPupil, request.IdMentor, cancellationToken);
            if (opinion is null)
            {
                throw new NotFoundException("Opinion not found");
            }
            await _opinionRepository.DeleteOpinionAsync(opinion, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
