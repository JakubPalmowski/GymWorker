using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Pupil;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Pupil.GetById;

public record GetPupilQuery(int Id) : IRequest<IEnumerable<PupilResponse>>
{

}
