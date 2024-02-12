using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.User.GetUserImage
{
    public class GetUserImageQueryHandler : IRequestHandler<GetUserImageQuery, UserImageResponse>
    {
        private readonly IRepository<Domain.Entities.User> _userBaseRepository;

        public GetUserImageQueryHandler(IRepository<Domain.Entities.User> userBaseRepository)
        {
            _userBaseRepository = userBaseRepository;
        }
        public async Task<UserImageResponse> Handle(GetUserImageQuery request, CancellationToken cancellationToken)
        {
            var user = await _userBaseRepository.GetByIdAsync(request.IdUser, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
            var userImage = new UserImageResponse
            {
                ImageUri = user.ImageUri
            };

            return userImage;
        }
    }
}
