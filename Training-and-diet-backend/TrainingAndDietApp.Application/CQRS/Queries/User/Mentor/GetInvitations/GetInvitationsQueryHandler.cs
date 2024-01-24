using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Mentor.GetInvitations
{
    public class GetInvitationsQueryHandler : IRequestHandler<GetInvitationsQuery, List<InvitationsResponse>>
    {
        private readonly IPupilMentorRepository _pupilMentorRepository;
        private readonly IMapper _mapper;

        public GetInvitationsQueryHandler(IPupilMentorRepository pupilMentorRepository, IMapper mapper)
        {
            _pupilMentorRepository = pupilMentorRepository;
            _mapper = mapper;
        }

        public async Task<List<InvitationsResponse>> Handle(GetInvitationsQuery request, CancellationToken cancellationToken)
        {
             var invitations = await _pupilMentorRepository.GetInvitationsAsync(request.IdMentor, cancellationToken);
            var invitationsResponse = _mapper.Map<List<InvitationsResponse>>(invitations.Select(x => x.Pupil));
            return invitationsResponse;
        }
    }
}
