using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.User.GetUserImage
{
    public record GetUserImageQuery(int IdUser) : IRequest<UserImageResponse>;
    
    public class UserImageResponse
    {
        public string? ImageUri { get; set; }
    }
}
