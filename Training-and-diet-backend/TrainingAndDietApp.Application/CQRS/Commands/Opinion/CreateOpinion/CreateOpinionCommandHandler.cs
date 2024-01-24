using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Opinion.CreateOpinion
{
    public class CreateOpinionCommandHandler : IRequestHandler<CreateOpinionInternalCommand>
    {
        private readonly IRepository<Domain.Entities.Opinion> _opinionBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPupilMentorRepository _pupilMentorRepository;
        private readonly IOpinionRepository _opinionRepository;

        public CreateOpinionCommandHandler(IOpinionRepository opinionRepository,IRepository<Domain.Entities.Opinion> opinionBaseRepository, IUnitOfWork unitOfWork, IPupilMentorRepository pupilMentorRepository)
        {
            _opinionBaseRepository = opinionBaseRepository;
            _unitOfWork = unitOfWork;   
            _pupilMentorRepository = pupilMentorRepository;
            _opinionRepository = opinionRepository;
        }


        public async Task Handle(CreateOpinionInternalCommand request, CancellationToken cancellationToken)
        {
            var cooperation = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.IdPupil, request.OpinionCommand.IdMentor, cancellationToken);
            if (cooperation == null && cooperation?.IsAccepted == false)
            {
                throw new System.Exception("Nie można dodać opinii dla tego mentora.");
            }
            var opinionExists = await _opinionRepository.GetPupilMentorOpinionAsync(request.IdPupil, request.OpinionCommand.IdMentor, cancellationToken);
            if (opinionExists != null)
            {
                throw new System.Exception("Opinia dla tego mentora już istnieje.");
            }


            var opinion = new Domain.Entities.Opinion()
            {
                IdMentor = request.OpinionCommand.IdMentor,
                IdPupil = request.IdPupil,
                Content = request.OpinionCommand.Content,
                Rate = request.OpinionCommand.Rate
            };
            await _opinionBaseRepository.AddAsync(opinion, cancellationToken);
            await _unitOfWork.CommitAsync();
            
        }
    }
}
