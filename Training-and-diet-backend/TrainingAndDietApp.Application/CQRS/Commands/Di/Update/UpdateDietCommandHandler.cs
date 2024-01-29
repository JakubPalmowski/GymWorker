using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.Di.Update
{
    public class UpdateDietCommandHandler : IRequestHandler<UpdateDietInternalCommand>
    {
        private readonly IRepository<Diet> _dietBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDietCommandHandler(IRepository<Domain.Entities.Diet> dietBaseRepository, IUnitOfWork unitOfWork, IMapper mapper)
       {
        _dietBaseRepository = dietBaseRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        
       }

        public async Task Handle(UpdateDietInternalCommand request, CancellationToken cancellationToken)
        {
            var diet = await _dietBaseRepository.GetByIdAsync(request.IdDiet, cancellationToken);
            if (diet == null)
            {
                throw new NotFoundException("Diet not found");
            }
            if (diet.IdDietician != request.IdDietician)
            {
                throw new BadRequestException("You are not allowed to update this diet");
            }
            _mapper.Map(request.CreateDietCommand, diet);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
