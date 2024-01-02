using AutoMapper;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.DTOs.Gym;
using TrainingAndDietApp.DAL.Repositories;

namespace TrainingAndDietApp.BLL.Services
{

    public interface IGymService
    {
        public Task<List<GymEntity>> GetGyms();
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


        public async Task<List<GymEntity>> GetGyms()
        {
            var gyms = await _gymRepository.GetGymsAsync();
            if (!gyms.Any())
                throw new Exception("No gyms found");



            return _mapper.Map<List<GymEntity>>(gyms);
        }
    }
}
