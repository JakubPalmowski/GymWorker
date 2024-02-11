using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetPupilDiets
{
    public class GetPupilDietsQueryHandler : IRequestHandler<GetPupilDietsQuery, List<DietPupilListResponse>>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetPupilDietsQueryHandler(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }

        public async Task<List<DietPupilListResponse>> Handle(GetPupilDietsQuery request, CancellationToken cancellationToken)
        {
            var diets = await _dietRepository.GetPupilDietsAsync(request.IdPupil, cancellationToken);
            if(!diets.Any())
                throw new NotFoundException("Diets not found");

            var dietsResponse = _mapper.Map<List<DietPupilListResponse>>(diets);
            return dietsResponse;
        }
    }
}
