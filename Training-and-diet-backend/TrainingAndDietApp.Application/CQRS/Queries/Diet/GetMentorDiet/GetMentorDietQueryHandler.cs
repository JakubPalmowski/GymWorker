using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Diet.GetMentorDiet
{
    public class GetMentorDietQueryHandler : IRequestHandler<GetMentorDietQuery, DietMentorResponse>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetMentorDietQueryHandler(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }
        public async Task<DietMentorResponse> Handle(GetMentorDietQuery request, CancellationToken cancellationToken)
        {
            var diet = await _dietRepository.GetMentorDietAsync(request.IdDiet, cancellationToken);
            if (diet == null)
                throw new NotFoundException("Diet not found");
            if (diet.IdDietician != request.IdDietician)
                throw new BadRequestException("You are not allowed to access this diet");

            return _mapper.Map<DietMentorResponse>(diet);
        }
    }
}
