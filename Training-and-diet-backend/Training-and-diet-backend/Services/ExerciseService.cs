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



        public IQueryable<Exercise> GetExerciseById(int ExerciseId)
        {
            var query =  _context.Exercises
                .Where(e => e.Id_Exercise == ExerciseId);

            if (query == null)
            {
                throw new NotFoundException("Exercise not found");
            }

            return query;
        }

        public async Task<int> CreateExercise(PostExerciseDTO exerciseDTO)
        {
           var exerciseToAdd = _mapper.Map<Exercise>(exerciseDTO);

            await _context.Exercises.AddAsync(exerciseToAdd);
            await _context.SaveChangesAsync();
            return exerciseToAdd.Id_Exercise;

        }
    }
}
