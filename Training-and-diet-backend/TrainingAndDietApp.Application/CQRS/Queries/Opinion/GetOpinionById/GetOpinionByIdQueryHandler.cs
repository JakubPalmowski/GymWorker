using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Opinion.GetOpinionById
{
    public class GetOpinionByIdQueryHandler : IRequestHandler<GetOpinionByIdQuery, OpinionEditResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOpinionRepository _opinionRepository;

        public GetOpinionByIdQueryHandler(IMapper mapper, IOpinionRepository opinionRepository)
        {
            _mapper = mapper;
            _opinionRepository = opinionRepository;
        }
        public async Task<OpinionEditResponse> Handle(GetOpinionByIdQuery request, CancellationToken cancellationToken)
        {
            var opinion = await _opinionRepository.GetPupilMentorOpinionAsync(request.IdPupil, request.IdMentor, cancellationToken);
            if (opinion == null)
            {
                throw new NotFoundException("Opinia dla tego mentora nie istnieje.");
            }
            var opinionResponse = _mapper.Map<OpinionEditResponse>(opinion);
            return opinionResponse;
        }
    }
}
