using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.DieticianTrainer.GetById
{
    public record class GetDieticianTrainerPersonalInfoQuery(int id) : IRequest<DieticianTrainerPersonalInfoResponse>
    {

    }
}
