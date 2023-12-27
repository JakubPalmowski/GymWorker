using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.DTOs.Gym;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;

namespace Training_and_diet_backend.Services
{

    public interface IGymService
    {
        public Task<List<GymDto>> GetGyms();
    }
    public class GymService : IGymService
    {
        private readonly IMapper _mapper;
        private readonly IGymRepository _gymRepository;

        public GymService(IGymRepository gymRepository, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _mapper = mapper;
        }


        public async Task<List<GymDto>> GetGyms()
        {
            var gyms = await _gymRepository.GetGymsAsync();
            if (!gyms.Any())
                throw new Exception("No gyms found");

            return _mapper.Map<List<GymDto>>(gyms);
        }
    }
}
