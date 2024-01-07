using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Enums;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.User;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserResponse<Domain.Entities.User>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetUsersQueryHandler(IMapper mapper, IUserRepository userRepository, IUserService userService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userService = userService;
    }
    public async Task<UserResponse<Domain.Entities.User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        if (request.RoleName != "Trainer" && request.RoleName != "Dietician")
            throw new BadRequestException("Role name must be Trainer, Dietician");

        var baseQuery = _userRepository.GetUsers(request.RoleName, request.Query?.SearchPhrase, cancellationToken);


        if (!string.IsNullOrEmpty(request.Query?.GymCityPhrase))
        {
            baseQuery = baseQuery.Where(u =>
                u.TrainerGyms.Any(g => g.Gym.Address.City.ToLower().Contains(request.Query.GymCityPhrase.ToLower())));
        }

        if (!string.IsNullOrEmpty(request.Query?.GymNamePhrase))
        {
            baseQuery = baseQuery.Where(u =>
                u.TrainerGyms.Any(g => g.Gym.Name.ToLower().Contains(request.Query.GymNamePhrase.ToLower())));
        }

        if (!string.IsNullOrEmpty(request.Query?.SortBy))
        {
            switch (request.Query?.SortBy)
            {
                case "MentorOpinions":
                    if (request.Query?.SortDirection == SortDirection.ASC)
                    {
                        baseQuery = baseQuery
                            .OrderBy(u => u.MentorOpinions.Any()
                                ? u.MentorOpinions.Average(mo => mo.Rate)
                                : 0);
                    }
                    else
                    {
                        baseQuery = baseQuery
                            .OrderByDescending(u => u.MentorOpinions.Any()
                            ? u.MentorOpinions.Average(mo => mo.Rate)
                                : 0);
                    }

                    break;

                case "PlanPrice":
                    if (request.Query?.SortDirection == SortDirection.ASC)
                    {
                        baseQuery = baseQuery.OrderBy(u => u.TrainingPlanPriceFrom == null)
                            .ThenBy(u => u.TrainingPlanPriceFrom ?? 0);
                    }
                    else
                    {
                        baseQuery = baseQuery
                            .OrderByDescending(u => u.TrainingPlanPriceTo ?? 0);
                    }

                    break;


                case "TrainingPrice":
                    if (request.Query?.SortDirection == SortDirection.ASC)
                    {
                        baseQuery = baseQuery.OrderBy(u => u.PersonalTrainingPriceFrom == null)
                            .ThenBy(u => u.PersonalTrainingPriceFrom ?? 0);
                    }
                    else
                    {
                        baseQuery = baseQuery
                            .OrderByDescending(u => u.PersonalTrainingPriceTo ?? 0);
                    }

                    break;

                case "DietPrice":
                    if (request.Query?.SortDirection == SortDirection.ASC)
                    {
                        baseQuery = baseQuery.OrderBy(u => u.DietPriceFrom == null)
                            .ThenBy(u => u.DietPriceFrom ?? 0);
                    }
                    else
                    {
                        baseQuery = baseQuery.OrderByDescending(u => u.DietPriceTo ?? 0);
                    }

                    break;
            }
        }


        var list = await baseQuery
            .Skip(9 * (request.Query.PageNumber - 1))
        .Take(9)
        .ToListAsync(cancellationToken: cancellationToken);

        var totalItemsCount = baseQuery.Count();

        var userResponse = _mapper.Map<List<MentorList>>(list);

        var result = new UserResponse<Domain.Entities.User>(userResponse, totalItemsCount, request.Query.PageNumber);


        if (list.Count == 0) throw new NotFoundException($"There are no {request.RoleName} in database");

        return result;
    }
}