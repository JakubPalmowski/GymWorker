using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{

    public interface IGymService
    {
        public Task<List<GymDto>> GetGyms();
    }
    public class GymService : IGymService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GymService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<GymDto>> GetGyms()
        {
            var gyms = await  _context.Gyms.Include(g => g.Address).ToListAsync();
            if (!gyms.Any())
                throw new Exception("No gyms found");

            return _mapper.Map<List<GymDto>>(gyms);

        }
    }
}
