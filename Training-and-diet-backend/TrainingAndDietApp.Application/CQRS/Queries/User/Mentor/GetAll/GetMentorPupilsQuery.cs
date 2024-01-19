using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Pupil;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Mentor.GetAll;

public record GetMentorPupilsQuery(int IdMentor) : IRequest<IEnumerable<MentorPupilResponse>>;
