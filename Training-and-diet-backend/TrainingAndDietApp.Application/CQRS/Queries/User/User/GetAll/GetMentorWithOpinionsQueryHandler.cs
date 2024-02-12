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
    private readonly IOpinionRepository _opinionRepository;
    private readonly IMapper _mapper;
    public GetMentorWithOpinionsQueryHandler(IOpinionRepository opinionRepository,IMapper mapper, IUserRepository userRepository, IUserService userService, IGymRepository gymRepository, IPupilMentorRepository pupilMentorRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userService = userService;
        _gymRepository = gymRepository;
        _pupilMentorRepository = pupilMentorRepository;
        _opinionRepository = opinionRepository; 

    }
    public async Task<MentorWithOpinionResponse> Handle(GetMentorWithOpinionsQuery request, CancellationToken cancellationToken)
    {
        if (!(request.RoleName == "Trainer" || request.RoleName == "Dietician"))
            throw new BadRequestException("User has wrong role");

        if (!await _userService.CheckIfUserExists(request.Id, cancellationToken))
            throw new NotFoundException("User not found");

        var user = await _userRepository.GetUserWithGymsAndOpinionsAsync(request.Id, cancellationToken);
        
        if (user!=null && user.IdRole != 3 && user.IdRole != 4 && user.IdRole != 5)
            throw new BadRequestException("User has wrong role");

        var mentorWithOpinionsResponse = _mapper.Map<MentorWithOpinionResponse>(user);

        if(request.IdLoggedUser!=null){
            var cooperation = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.IdLoggedUser.Value, request.Id, cancellationToken);
            if(cooperation!=null){
                if(cooperation.IsAccepted){
                    mentorWithOpinionsResponse.Cooperation = true;
                    var opinion = await _opinionRepository.GetPupilMentorOpinionAsync(request.IdLoggedUser.Value, request.Id, cancellationToken);
                    if(opinion!=null){
                        mentorWithOpinionsResponse.IsOpinionExists = true;
                    }
                    else{
                        mentorWithOpinionsResponse.IsOpinionExists = false;
                    }
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