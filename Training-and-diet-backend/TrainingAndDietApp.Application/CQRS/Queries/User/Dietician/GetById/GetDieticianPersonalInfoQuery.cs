using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Dietician;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Dietician.GetById
{
    public record class GetDieticianPersonalInfoQuery(int id) : IRequest<DieticianPersonalInfoResponse>
    {

    }

}
