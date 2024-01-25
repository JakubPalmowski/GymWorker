using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.User.AcceptInvitation
{

    public class AcceptInvitationCommandHandler : IRequestHandler<AcceptInvitationCommand>
    {
        private readonly IPupilMentorRepository _pupilMentorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PupilMentor> _pupilMentorBaseRepository;

        public AcceptInvitationCommandHandler(IPupilMentorRepository pupilMentorRepository, IUnitOfWork unitOfWork, IRepository<Domain.Entities.PupilMentor> pupilMentorBaseRepository)
        {
            _pupilMentorRepository = pupilMentorRepository;
            _unitOfWork = unitOfWork;
            _pupilMentorBaseRepository = pupilMentorBaseRepository;
        }
        public async Task Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
        {
            var cooperation = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.IdPupil, request.IdMentor, cancellationToken);
            if (cooperation == null)
            {
                throw new BadRequestException("Pupil is not cooperating with this mentor");
            }
            if (cooperation.IsAccepted == true)
            {
                throw new BadRequestException("Pupil is already cooperating with this mentor");
            }
            cooperation.IsAccepted = true;
            await _pupilMentorBaseRepository.UpdateAsync(cooperation, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
