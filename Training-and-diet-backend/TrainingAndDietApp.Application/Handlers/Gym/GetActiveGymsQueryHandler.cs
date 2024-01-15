using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.Application.Queries.Gym;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Application.Responses.Gym;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Gym;

public class GetActiveGymsQueryHandler : IRequestHandler<GetActiveGymsQuery, IEnumerable<ActiveGymResponse>>
{
    private readonly IGymRepository _repository;
    private readonly IMapper _mapper;

    public GetActiveGymsQueryHandler(IMapper mapper, IGymRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<ActiveGymResponse>> Handle(GetActiveGymsQuery request, CancellationToken cancellationToken)
    {
        var gyms = await _repository.GetActiveGymsWithAddressAsync(cancellationToken);
        if (gyms == null)
            throw new NotFoundException("Gyms not Found");
        return _mapper.Map<List<ActiveGymResponse>>(gyms);
    }
}