using MediatR;
using TrainingAndDietApp.Application.Responses.Trainer;

namespace TrainingAndDietApp.Application.Queries.User
{
    public record class GetTrainerPersonalInfoQuery(int id) : IRequest<TrainerPersonalInfoResponse>
    {
    }
}
