using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Exceptions;
using AutoMapper;

namespace Training_and_diet_backend.Services
{
    public interface IExerciseService
    {
        Task<ExerciseDTO> GetExerciseById(int ExerciseId);
        Task<List<GetAllExercisesDTO>> GetAllExercises();
        Task<int> CreateExercise(ExerciseDTO exerciseDTO);


        Task<ExerciseDTO> UpdateExercise(ExerciseDTO exercise, int ExerciseId);
    }
    public class ExerciseService:IExerciseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ExerciseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllExercisesDTO>> GetAllExercises()
        {
            var result = await _context.Exercises
                .Select(exercise => new GetAllExercisesDTO
                {
                    Name = exercise.Name,
                    Id_Exercise = exercise.Id_Exercise
                })
                .ToListAsync();

            if (result == null)
            {
                throw new NotFoundException("Exercises not found");
            }

            return result;
        }

        public async Task<ExerciseDTO> GetExerciseById(int ExerciseId)
        {
            var query = await _context.Exercises
                .Where(e => e.Id_Exercise == ExerciseId).FirstOrDefaultAsync();

            if (query == null)
            {
                throw new NotFoundException("Exercise not found");
            }

            var result = _mapper.Map<ExerciseDTO>(query);

            return result;
        }

        public async Task<int> CreateExercise(ExerciseDTO exerciseDTO)
        {
           var exerciseToAdd = _mapper.Map<Exercise>(exerciseDTO);

            await _context.Exercises.AddAsync(exerciseToAdd);
            await _context.SaveChangesAsync();
            return exerciseToAdd.Id_Exercise;

        }

        public async Task<ExerciseDTO> UpdateExercise(ExerciseDTO exerciseDTO, int ExerciseId)
        {
           var exercise = await _context.Exercises.FindAsync(ExerciseId);

           if (exercise == null)
           {
                throw new NotFoundException("Exercise not found");
           }
           exerciseDTO.Id_Exercise = ExerciseId;

           _mapper.Map(exerciseDTO, exercise);
           _context.Exercises.Update(exercise);
           await _context.SaveChangesAsync();

           var result = _mapper.Map<ExerciseDTO>(exercise);

            return result;
        }
    }
}
