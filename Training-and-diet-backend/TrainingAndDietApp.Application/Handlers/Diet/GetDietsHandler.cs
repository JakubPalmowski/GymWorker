using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries.Diet;
using TrainingAndDietApp.Application.Responses.Diet;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Diet
{
    public class GetDietsHandler :  IRequestHandler<GetDietsQuery, IEnumerable<DietResponse>>
    {
        private readonly IDietRepository _repository;
        private readonly IMapper _mapper;

        public GetDietsHandler(IDietRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DietResponse>> Handle(GetDietsQuery request, CancellationToken cancellationToken)
        {
            var diets = await _repository.GetDietsAsync(cancellationToken);
            if (diets == null)
                throw new NotFoundException("No diets found");

            return _mapper.Map<List<DietResponse>>(diets);
            
        }
    }
}
