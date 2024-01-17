using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll;

public class GetMentorWithOpinionsQueryHandler : IRequestHandler<GetMentorWithOpinionsQuery, MentorWithOpinionResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetMentorWithOpinionsQueryHandler(IMapper mapper, IUserRepository userRepository, IUserService userService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userService = userService;

    }
    public async Task<MentorWithOpinionResponse> Handle(GetMentorWithOpinionsQuery request, CancellationToken cancellationToken)
    {
        if (!(request.RoleName == "Trainer" || request.RoleName == "Dietician"))
            throw new BadRequestException("User has wrong role");

        if (!await _userService.CheckIfUserExists(request.Id, cancellationToken))
            throw new NotFoundException("User not found");

        var user = await _userRepository.GetUserWithGymsAndOpinionsAsync(request.Id, cancellationToken);



        var mentorWithOpinionsResponse = _mapper.Map<MentorWithOpinionResponse>(user);


        mentorWithOpinionsResponse.TotalRate = user.MentorOpinions.Any()
            ? user.MentorOpinions.Average(o => o.Rate)
            : 0m;
        mentorWithOpinionsResponse.OpinionNumber = user.MentorOpinions.Count;

        mentorWithOpinionsResponse.Opinions = _mapper.Map<List<OpinionResponse>>(user.MentorOpinions);
        mentorWithOpinionsResponse.TrainerGyms = _mapper.Map<List<MentorGymResponse>>(user.TrainerGyms);

        return mentorWithOpinionsResponse;




    }
}