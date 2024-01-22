using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserInfoForVerification
{
    public class GetUserInfoForVerificationQuery : IRequest<GetUserInfoForVerificationQuery>
    {
        public GetUserInfoForVerificationQuery(int idUser)
        {
            IdUser = idUser;
        }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdRole { get; set; }
        public int IsAccepted { get; set; }
    }
}
