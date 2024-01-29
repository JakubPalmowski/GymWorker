using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetPupilDiet
{
    public class GetPupilDietQueryHandler : IRequestHandler<GetPupilDietQuery, DietPupilResponse>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetPupilDietQueryHandler(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
            
        }
        public async Task<DietPupilResponse> Handle(GetPupilDietQuery request, CancellationToken cancellationToken)
        {
            var diet = await _dietRepository.GetPupilDietAsync(request.IdDiet, cancellationToken);
            if (diet == null)
                throw new NotFoundException("Diet not found");
            if (diet.IdPupil != request.IdPupil)
                throw new BadRequestException("You are not allowed to access this diet");
            return _mapper.Map<DietPupilResponse>(diet);
        }
    }
}
