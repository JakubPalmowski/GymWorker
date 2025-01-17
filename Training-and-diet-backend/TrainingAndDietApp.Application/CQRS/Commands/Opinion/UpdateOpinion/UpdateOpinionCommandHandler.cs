using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Opinion.UpdateOpinion
{
    public class UpdateOpinionCommandHandler : IRequestHandler<UpdateOpinionInternalCommand>
    {
        private readonly IRepository<Domain.Entities.Opinion> _opinionBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPupilMentorRepository _pupilMentorRepository;
        private readonly IOpinionRepository _opinionRepository;

        public UpdateOpinionCommandHandler(IRepository<Domain.Entities.Opinion> opinionBaseRepository, IUnitOfWork unitOfWork, IPupilMentorRepository pupilMentorRepository, IOpinionRepository opinionRepository)
        {
            _opinionBaseRepository = opinionBaseRepository;
            _unitOfWork = unitOfWork;
            _pupilMentorRepository = pupilMentorRepository;
            _opinionRepository = opinionRepository;
        }

        public async Task Handle(UpdateOpinionInternalCommand request, CancellationToken cancellationToken)
        {
           var cooperation = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.IdPupil, request.UpdateCommand.IdMentor, cancellationToken);
              if (cooperation == null && cooperation?.IsAccepted == false)
              {
                throw new BadRequestException("You cannot add opinion for this mentor");
              }
              var opinion = await _opinionRepository.GetPupilMentorOpinionAsync(request.IdPupil, request.UpdateCommand.IdMentor, cancellationToken);
              if (opinion == null)
              {
                  throw new ConflictException("Opinion for this mentor already exists");
              }
              opinion.Content = request.UpdateCommand.Content;
              opinion.Rate = request.UpdateCommand.Rate;
              await _opinionBaseRepository.UpdateAsync(opinion, cancellationToken);
              await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
