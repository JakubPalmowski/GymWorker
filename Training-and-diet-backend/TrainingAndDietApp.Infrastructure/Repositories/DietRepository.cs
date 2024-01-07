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
        public async Task<List<Diet>> GetDietsAsync(CancellationToken cancellationToken)
        {
            return await _context.Diets.ToListAsync(cancellationToken);
        }
    }
}
