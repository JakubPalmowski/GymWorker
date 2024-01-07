using MediatR;
using TrainingAndDietApp.Application.Responses.Pupil;

namespace TrainingAndDietApp.Application.Queries.User;

public record GetPupilQuery(int Id) : IRequest<IEnumerable<PupilResponse>>
{
    
}
