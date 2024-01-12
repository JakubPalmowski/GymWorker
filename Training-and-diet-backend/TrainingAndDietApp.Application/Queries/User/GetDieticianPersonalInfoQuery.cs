using MediatR;
using TrainingAndDietApp.Application.Responses.Dietician;

namespace TrainingAndDietApp.Application.Queries.User
{
    public record class GetDieticianPersonalInfoQuery(int id) : IRequest<DieticianPersonalInfoResponse>{

    }
   
}
