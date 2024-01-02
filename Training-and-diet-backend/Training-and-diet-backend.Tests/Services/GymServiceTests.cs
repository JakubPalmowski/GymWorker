using AutoMapper;
using FluentAssertions;
using Moq;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.Common.DTOs.Gym;
using TrainingAndDietApp.DAL.Repositories;

public class GymServiceTests
{
    private readonly Mock<IGymRepository> _mockGymRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly GymService _gymService;

    public GymServiceTests()
    {
        _mockGymRepository = new Mock<IGymRepository>();
        _mockMapper = new Mock<IMapper>();
        _gymService = new GymService(_mockGymRepository.Object, _mockMapper.Object);
    }



    [Fact]
    public async Task GetGyms_ReturnsListOfGymDto_WhenGymsExist()
    {
        var gyms = new List<GymEntity>
        {
            new GymEntity
            {
                IdGym = 1,
                Name = "Si³ownia 1",
                AddressEntity = new AddressEntity
                {
                    IdAddress = 1,
                    City = "Warszawa",
                    Street = "Marsza³kowska"
                }
            },
            new GymEntity
            {
                IdGym = 2,
                Name = "Si³ownia 2",
                AddressEntity = new AddressEntity
                {
                    IdAddress = 2,
                    City = "Warszawa",
                    Street = "Marsza³kowska"
                }
            },
            new GymEntity
            {
                IdGym = 3,
                Name = "Si³ownia 3",
                AddressEntity = new AddressEntity
                {
                    IdAddress = 3,
                    City = "Warszawa",
                    Street = "Marsza³kowska"
                }
            }
        };

        var expectedGymDtos = gyms.Select(g => new GymDto
        {
            Name = g.Name,
            CityName = g.AddressEntity.City,
            Street = g.AddressEntity.Street
        }).ToList();

        _mockGymRepository.Setup(repo => repo.GetGymsAsync()).ReturnsAsync(gyms);
        _mockMapper.Setup(mapper => mapper.Map<List<GymDto>>(It.IsAny<List<GymEntity>>()))
            .Returns(expectedGymDtos); 

   
        var result = await _gymService.GetGyms();


        result.Should().BeEquivalentTo(expectedGymDtos);

    }

    [Fact]
    public async Task GetGyms_ThrowsException_WhenNoGymsFound()
    {
        _mockGymRepository.Setup(repo => repo.GetGymsAsync()).ReturnsAsync(new List<GymEntity>());

        await Assert.ThrowsAsync<Exception>(() => _gymService.GetGyms());
    }
}

