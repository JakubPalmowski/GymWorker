using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Exercise
{
    public class GetExerciseQueryHandler : IRequestHandler<GetExerciseQuery, ExerciseResponse>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        public GetExerciseQueryHandler(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }
        public async Task<ExerciseResponse> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(request.IdExercise, cancellationToken);
            if (exercise == null)
                throw new NotFoundException("Exercise not found");

            return _mapper.Map<ExerciseResponse>(exercise);

        }

    }
}