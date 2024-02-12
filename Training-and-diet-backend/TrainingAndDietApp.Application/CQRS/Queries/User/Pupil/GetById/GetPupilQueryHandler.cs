using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.Pupil;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Pupil.GetById
{
    public class GetPupilQueryHandler : IRequestHandler<GetPupilQuery, PupilResponse>
    {
        private readonly IRepository<Domain.Entities.User> _userBaseRepository;
        private readonly IUserService _userService;
        private readonly IPupilMentorRepository _pupilMentorRepository;
        private readonly IMapper _mapper;
        public GetPupilQueryHandler(IMapper mapper, IRepository<Domain.Entities.User> userBaseRepository, IUserService userService, IPupilMentorRepository pupilMentorRepository)
        {
            _mapper = mapper;
            _userBaseRepository = userBaseRepository;
            _userService = userService;
            _pupilMentorRepository = pupilMentorRepository;

        }
        public async Task<PupilResponse> Handle(GetPupilQuery request, CancellationToken cancellationToken)
        {
                var pupil = await _userBaseRepository.GetByIdAsync(request.IdPupil, cancellationToken);
                if (pupil == null)
                    throw new NotFoundException("User not found");
                if(! await _userService.CheckIfUserIsPupil(pupil.IdUser, cancellationToken))
                    throw new BadRequestException("User is not a pupil");
                var cooperation = await _pupilMentorRepository.IsPupilCooperatingWithMentor(request.IdPupil,request.IdMentor, cancellationToken);
                if(cooperation == null){
                    throw new BadRequestException("Pupil is not cooperating with this mentor");
                }
                var PupilResponse = _mapper.Map<PupilResponse>(pupil);
                return PupilResponse;
            
    }
}
}
