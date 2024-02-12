using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.Di.Create
{
    public class CreateDietCommandHandler : IRequestHandler<CreateDietInternalCommand, CreateDietResponse>
    {
        private readonly IRepository<Diet> _dietBaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDietCommandHandler(IRepository<Domain.Entities.Diet> dietBaseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _dietBaseRepository = dietBaseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateDietResponse> Handle(CreateDietInternalCommand request, CancellationToken cancellationToken)
        {
            var diet = _mapper.Map<Diet>(request.CreateDietCommand);
            diet.IdDietician = request.IdDietician;
            await _dietBaseRepository.AddAsync(diet, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new CreateDietResponse { IdDiet = diet.IdDiet};
        }
    }
}
