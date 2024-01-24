using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.User.DeleteInvitation
{
    public class DeleteInvitationCommandHandler : IRequestHandler<DeleteInvitationCommand>
    {
        private readonly IPupilMentorRepository _pupilMentorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvitationCommandHandler(IPupilMentorRepository pupilMentorRepository , IUnitOfWork unitOfWork)
        {
            _pupilMentorRepository = pupilMentorRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteInvitationCommand request, CancellationToken cancellationToken)
        {
            var cooperating = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.Id, request.SecondId, cancellationToken);
            var cooperating2 = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.SecondId, request.Id, cancellationToken);
            if (cooperating == null && cooperating2 == null)
            {
                throw new NotFoundException("You can't delete invitation.");
            }
            if (cooperating != null)
            {
                if(cooperating.IsAccepted == true)
                {
                    throw new BadRequestException("You can't delete invitation.");
                }
                await _pupilMentorRepository.DeletePupilMentorAsync(cooperating, cancellationToken);
            }
            if (cooperating2 != null)
            {
                if (cooperating2.IsAccepted == true)
                {
                    throw new BadRequestException("You can't delete invitation.");
                }
                await _pupilMentorRepository.DeletePupilMentorAsync(cooperating2, cancellationToken);
            }
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
