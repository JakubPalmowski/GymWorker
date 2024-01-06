using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.Application.Queries.Gym;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Application.Responses.Gym;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Repositories;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Gym;

public class GetGymsQueryHandler : IRequestHandler<GetGymsQuery, IEnumerable<GymResponse>>
{
    private readonly IGymRepository _gymRepository;
    private readonly IMapper _mapper;

    public GetGymsQueryHandler(IGymRepository gymRepository, IMapper mapper)
    {
        _gymRepository = gymRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GymResponse>> Handle(GetGymsQuery request, CancellationToken cancellationToken)
    {
        var gyms = await _gymRepository.GetGymsAsync();
        if (gyms == null)
            throw new NotFoundException("Gyms not Found");
        return _mapper.Map<List<GymResponse>>(gyms);
    }
}