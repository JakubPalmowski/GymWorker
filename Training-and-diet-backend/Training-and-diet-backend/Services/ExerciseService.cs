using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_and_diet_backend.Services
{
    public class ExerciseService:IExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Exercise> GetExerciseById(int ExerciseId)
        {
            return _context.Exercises
                .Where(e => e.Id_Exercise == ExerciseId);
        }
    }
}
