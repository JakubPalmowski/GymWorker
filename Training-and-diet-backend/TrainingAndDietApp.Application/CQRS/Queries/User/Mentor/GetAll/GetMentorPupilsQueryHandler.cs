using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Pupil;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Mentor.GetAll;

public class GetMentorPupilsQueryHandler : IRequestHandler<GetMentorPupilsQuery, IEnumerable<MentorPupilResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetMentorPupilsQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MentorPupilResponse>> Handle(GetMentorPupilsQuery request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetPupilsByTrainerIdAsync(request.IdMentor, cancellationToken);
        if (result is null) 
            throw new NotFoundException("Pupils not found");

        return _mapper.Map<List<MentorPupilResponse>>(result);
    }
}