using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetGymByIdAdmin
{
    public class GetGymByIdAdminQuery : IRequest<GetGymByIdAdminQuery>
    {
        public GetGymByIdAdminQuery(int idGym)
        {
            IdGym = idGym;
        }

        public int IdGym { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Status { get; set; }
    }


}
