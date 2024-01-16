using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Gym.GetAll;

public class GetGymsQueryHandler : IRequestHandler<GetGymsQuery, IEnumerable<GymResponse>>
{
    private readonly IGymRepository _repository;
    private readonly IMapper _mapper;

    public GetGymsQueryHandler(IMapper mapper, IGymRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<GymResponse>> Handle(GetGymsQuery request, CancellationToken cancellationToken)
    {
        var gyms = await _repository.GetGymsWithAddressAsync(cancellationToken);
        if (gyms == null)
            throw new NotFoundException("Gyms not Found");
        return _mapper.Map<List<GymResponse>>(gyms);
    }
}