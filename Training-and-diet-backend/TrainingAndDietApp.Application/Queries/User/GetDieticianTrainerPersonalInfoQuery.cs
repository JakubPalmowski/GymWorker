using MediatR;

namespace TrainingAndDietApp.Application.Queries.User
{
    public record class GetDieticianTrainerPersonalInfoQuery(int id) : IRequest<DieticianTrainerPersonalInfoResponse>
    {
        
    }
}
