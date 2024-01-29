using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetDieticianDiets
{
    public class GetDieticianDietsQueryHandler : IRequestHandler<GetDieticianDietsQuery, List<DietDieticianListResponse>>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetDieticianDietsQueryHandler(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }
        public async Task<List<DietDieticianListResponse>> Handle(GetDieticianDietsQuery request, CancellationToken cancellationToken)
        {
            var diets = await _dietRepository.GetDieticianDietsAsync(request.IdDietician, cancellationToken);
            var dietsResponse = _mapper.Map<List<DietDieticianListResponse>>(diets);
            return dietsResponse;
        }
    }
}
