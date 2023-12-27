using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_and_diet_backend.Exceptions;
using AutoMapper;
using Training_and_diet_backend.Repositories;
using Training_and_diet_backend.DTOs.Exercise;

namespace Training_and_diet_backend.Services
{
    public interface IExerciseService
    {
        Task<ExerciseDto> GetExerciseById(int ExerciseId);
        Task<List<ExerciseNameDto>> GetAllExercises();
        Task<int> CreateExercise(ExerciseDto exerciseDTO);


        Task<ExerciseDto> UpdateExercise(ExerciseDto exercise, int ExerciseId);
    }
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExerciseNameDto>> GetAllExercises()
        {
            var exercises = await _exerciseRepository.GetAllExercisesAsync();

            if (exercises == null)
            {
                throw new NotFoundException("Exercises not found");
            }

            return _mapper.Map<List<ExerciseNameDto>>(exercises);
        }

        public async Task<ExerciseDto> GetExerciseById(int ExerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(ExerciseId);

            if (exercise == null)
            {
                throw new NotFoundException("Exercise not found");
            }

            return _mapper.Map<ExerciseDto>(exercise);
        }

        public async Task<int> CreateExercise(ExerciseDto exerciseDTO)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            return await _exerciseRepository.CreateExerciseAsync(exercise);
        }

        public async Task<ExerciseDto> UpdateExercise(ExerciseDto exerciseDTO, int ExerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(ExerciseId);

            if (exercise == null)
            {
                throw new NotFoundException("Exercise not found");
            }

            _mapper.Map(exerciseDTO, exercise);
            await _exerciseRepository.UpdateExerciseAsync(exercise);

            return _mapper.Map<ExerciseDto>(exercise);
        }
    }
}
