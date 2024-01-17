using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetById
{
    public class GetExerciseQueryHandler : IRequestHandler<GetExerciseQuery, ExerciseResponse>
    {
        private readonly IRepository<Domain.Entities.Exercise> _repository;
        private readonly IMapper _mapper;
        public GetExerciseQueryHandler(IMapper mapper, IRepository<Domain.Entities.Exercise> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ExerciseResponse> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _repository.GetByIdAsync(request.IdExercise, cancellationToken);
            if (exercise == null)
                throw new NotFoundException("Exercise not found");

            return _mapper.Map<ExerciseResponse>(exercise);

        }

    }
}