using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.User.Pupil.SendInvitation
{
    public class SendInvitationCommandHandler : IRequestHandler<SendInvitationCommand>
    {
        private readonly IPupilMentorRepository _pupilMentorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PupilMentor> _pupilMentorBaseRepository;

        public SendInvitationCommandHandler(IPupilMentorRepository pupilMentorRepository, IUnitOfWork unitOfWork, IRepository<PupilMentor> pupilMentorBaseRepository)
        {
            _pupilMentorRepository = pupilMentorRepository;
            _unitOfWork = unitOfWork;
            _pupilMentorBaseRepository = pupilMentorBaseRepository;
        }
        public async Task Handle(SendInvitationCommand request, CancellationToken cancellationToken)
        {
            var pupilMentor = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.IdPupil, request.IdMentor, cancellationToken);
            if (pupilMentor != null)
                throw new BadRequestException("You are already cooperating with this mentor.");
            
            var pupilMentorEntity = new PupilMentor
            {
                IdMentor = request.IdMentor,
                IdPupil = request.IdPupil,
                IsAccepted = false
            };
            await _pupilMentorBaseRepository.AddAsync(pupilMentorEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
