﻿using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Exceptions;
using AutoMapper;
using Training_and_diet_backend.Repositories;

namespace Training_and_diet_backend.Services
{
    public interface IExerciseService
    {
        Task<ExerciseDTO> GetExerciseById(int ExerciseId);
        Task<List<GetAllExercisesDTO>> GetAllExercises();
        Task<int> CreateExercise(ExerciseDTO exerciseDTO);


        Task<ExerciseDTO> UpdateExercise(ExerciseDTO exercise, int ExerciseId);
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

        public async Task<List<GetAllExercisesDTO>> GetAllExercises()
        {
            var exercises = await _exerciseRepository.GetAllExercisesAsync();

            if (exercises == null)
            {
                throw new NotFoundException("Exercises not found");
            }

            return _mapper.Map<List<GetAllExercisesDTO>>(exercises);
        }

        public async Task<ExerciseDTO> GetExerciseById(int ExerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(ExerciseId);

            if (exercise == null)
            {
                throw new NotFoundException("Exercise not found");
            }

            return _mapper.Map<ExerciseDTO>(exercise);
        }

        public async Task<int> CreateExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            return await _exerciseRepository.CreateExerciseAsync(exercise);
        }

        public async Task<ExerciseDTO> UpdateExercise(ExerciseDTO exerciseDTO, int ExerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(ExerciseId);

            if (exercise == null)
            {
                throw new NotFoundException("Exercise not found");
            }

            _mapper.Map(exerciseDTO, exercise);
            await _exerciseRepository.UpdateExerciseAsync(exercise);

            return _mapper.Map<ExerciseDTO>(exercise);
        }
    }
}
