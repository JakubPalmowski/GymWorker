using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{
    public class DietRepository : IDietRepository
    {
        private readonly ApplicationDbContext _context;

        public DietRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Diet>> GetDieticianDietsAsync(int dieticianId, CancellationToken cancellationToken)
        => await _context.Diets.Where(diet => diet.IdDietician == dieticianId).ToListAsync(cancellationToken);
        
    }
}
