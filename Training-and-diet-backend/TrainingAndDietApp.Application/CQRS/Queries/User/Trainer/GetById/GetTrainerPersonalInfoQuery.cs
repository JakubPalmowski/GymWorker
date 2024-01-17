using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Trainer;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Trainer.GetById
{
    public record class GetTrainerPersonalInfoQuery(int id) : IRequest<TrainerPersonalInfoResponse>
    {
    }
}
