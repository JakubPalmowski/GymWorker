using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses.Pupil;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User.Pupil
{
    public class GetPupilQueryHandler : IRequestHandler<GetPupilQuery, IEnumerable<PupilResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetPupilQueryHandler(IMapper mapper, IUserRepository userRepository, IUserService userService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userService = userService;

        }
        public async Task<IEnumerable<PupilResponse>> Handle(GetPupilQuery request, CancellationToken cancellationToken)
        {
            if(! await _userService.CheckIfUserExists(request.Id,cancellationToken))
                throw new NotFoundException("User not found");
            if(!(await _userService.CheckIfUserIsTrainer(request.Id, cancellationToken) ||
                    await _userService.CheckIfUserIsDietician(request.Id, cancellationToken) ||
                    await _userService.CheckIfUserIsDieticianTrainer(request.Id, cancellationToken)))
                throw new BadRequestException("User is not a mentor");
            

            var pupil = await _userRepository.GetPupilsByTrainerIdAsync(request.Id, cancellationToken);
            var pupilResponse = _mapper.Map<List<PupilResponse>>(pupil);

            return pupilResponse;
        }
    }
}
