﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetAll
{
    public class GetDietsHandler : IRequestHandler<GetDietsQuery, IEnumerable<DietResponse>>
    {
        private readonly IRepository<Domain.Entities.Diet> _repository;
        private readonly IMapper _mapper;

        public GetDietsHandler(IRepository<Domain.Entities.Diet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DietResponse>> Handle(GetDietsQuery request, CancellationToken cancellationToken)
        {
            var diets = await _repository.GetAllAsync(cancellationToken);
            if (diets == null)
                throw new NotFoundException("No diets found");

            return _mapper.Map<List<DietResponse>>(diets);

        }
    }
}
