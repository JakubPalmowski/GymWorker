using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Mentor.GetInvitations
{
    public record GetInvitationsQuery(int IdMentor) : IRequest<List<InvitationsResponse>>;
    

    public class InvitationsResponse
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? ImageUri { get; set; }
    }

}
