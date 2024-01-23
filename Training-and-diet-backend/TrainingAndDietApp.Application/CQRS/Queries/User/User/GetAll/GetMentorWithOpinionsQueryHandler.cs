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
    private readonly IGymRepository _gymRepository;
    private readonly IPupilMentorRepository _pupilMentorRepository;
    private readonly IMapper _mapper;
    public GetMentorWithOpinionsQueryHandler(IMapper mapper, IUserRepository userRepository, IUserService userService, IGymRepository gymRepository, IPupilMentorRepository pupilMentorRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userService = userService;
        _gymRepository = gymRepository;
        _pupilMentorRepository = pupilMentorRepository;

    }
    public async Task<MentorWithOpinionResponse> Handle(GetMentorWithOpinionsQuery request, CancellationToken cancellationToken)
    {
        if (!(request.RoleName == "Trainer" || request.RoleName == "Dietician"))
            throw new BadRequestException("User has wrong role");

        if (!await _userService.CheckIfUserExists(request.Id, cancellationToken))
            throw new NotFoundException("User not found");

        var user = await _userRepository.GetUserWithGymsAndOpinionsAsync(request.Id, cancellationToken);
        
            


        var mentorWithOpinionsResponse = _mapper.Map<MentorWithOpinionResponse>(user);

        if(request.IdLoggedUser!=null){
            var cooperation = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.IdLoggedUser.Value, request.Id, cancellationToken);
            if(cooperation!=null){
                if(cooperation.IsAccepted){
                    mentorWithOpinionsResponse.Cooperation = true;
                }
                else{
                    mentorWithOpinionsResponse.Cooperation = false;
                }
            }
            
        }
        mentorWithOpinionsResponse.TotalRate = user.MentorOpinions.Any()
            ? user.MentorOpinions.Average(o => o.Rate)
            : 0m;
        mentorWithOpinionsResponse.OpinionNumber = user.MentorOpinions.Count;

        mentorWithOpinionsResponse.Opinions = _mapper.Map<List<OpinionResponse>>(user.MentorOpinions);
        var mentorGyms = await _gymRepository.GetMentorActiveGymsAsync(request.Id, cancellationToken);
        mentorWithOpinionsResponse.TrainerGyms = _mapper.Map<List<MentorGymResponse>>(mentorGyms);

        return mentorWithOpinionsResponse;




    }
}