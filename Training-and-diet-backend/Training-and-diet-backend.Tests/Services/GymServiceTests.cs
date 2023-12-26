using AutoMapper;
using FluentAssertions;
using Moq;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using Training_and_diet_backend.Services;

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
        var gyms = new List<Gym>
        {
            new Gym
            {
                Id_Gym = 1,
                Name = "Si³ownia 1",
                Address = new Address
                {
                    Id_Address = 1,
                    City = "Warszawa",
                    Street = "Marsza³kowska"
                }
            },
            new Gym
            {
                Id_Gym = 2,
                Name = "Si³ownia 2",
                Address = new Address
                {
                    Id_Address = 2,
                    City = "Warszawa",
                    Street = "Marsza³kowska"
                }
            },
            new Gym
            {
                Id_Gym = 3,
                Name = "Si³ownia 3",
                Address = new Address
                {
                    Id_Address = 3,
                    City = "Warszawa",
                    Street = "Marsza³kowska"
                }
            }
        };

        var expectedGymDtos = gyms.Select(g => new GymDto
        {
            Name = g.Name,
            CityName = g.Address.City,
            Street = g.Address.Street
        }).ToList();

        _mockGymRepository.Setup(repo => repo.GetGymsAsync()).ReturnsAsync(gyms);
        _mockMapper.Setup(mapper => mapper.Map<List<GymDto>>(It.IsAny<List<Gym>>()))
            .Returns(expectedGymDtos); 

   
        var result = await _gymService.GetGyms();


        result.Should().BeEquivalentTo(expectedGymDtos);

    }

    [Fact]
    public async Task GetGyms_ThrowsException_WhenNoGymsFound()
    {
        _mockGymRepository.Setup(repo => repo.GetGymsAsync()).ReturnsAsync(new List<Gym>());

        await Assert.ThrowsAsync<Exception>(() => _gymService.GetGyms());
    }
}

