using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Commands.Admin.VerifyUser
{
    public class VerifyUserCommandHandler : IRequestHandler<VerifyUserInternalCommand>
    {
        private readonly IRepository<Domain.Entities.User> _userBaseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VerifyUserCommandHandler(IRepository<Domain.Entities.User> userBaseRepository, IUnitOfWork unitOfWork)
        {
            _userBaseRepository = userBaseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(VerifyUserInternalCommand request, CancellationToken cancellationToken)
        {
            var user = await _userBaseRepository.GetByIdAsync(request.IdUser, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("Nie znaleziono użytkownika");
            }
            user.IdRole = request.VerifyUserCommand.IdRole;
            user.IsAccepted = request.VerifyUserCommand.IsAccepted;
            await _userBaseRepository.UpdateAsync(user, cancellationToken);
            await _unitOfWork.CommitAsync();
        }
    }
}
