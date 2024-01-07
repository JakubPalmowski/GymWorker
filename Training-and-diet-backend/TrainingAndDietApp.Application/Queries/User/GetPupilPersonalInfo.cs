using MediatR;
using TrainingAndDietApp.Application.Responses.Pupil;

namespace TrainingAndDietApp.Application.Queries.User;

public record GetPupilPersonalInfo(int Id) : IRequest<IEnumerable<PupilPersonalInfoResponse>>
{
    
}