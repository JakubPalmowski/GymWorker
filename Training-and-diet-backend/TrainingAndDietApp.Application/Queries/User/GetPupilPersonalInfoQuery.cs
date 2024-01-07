using MediatR;
using TrainingAndDietApp.Application.Responses.Pupil;

namespace TrainingAndDietApp.Application.Queries.User;

public record GetPupilPersonalInfoQuery(int Id) : IRequest<PupilPersonalInfoResponse>
{
    
}