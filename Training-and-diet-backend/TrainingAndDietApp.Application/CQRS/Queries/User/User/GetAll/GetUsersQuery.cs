﻿using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses;
using TrainingAndDietApp.Application.Enums;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll
{
    public record class GetUsersQuery(string RoleName, UserQuery? Query = null) : IRequest<UserResponse<Domain.Entities.User>>
    {
    }

    public class UserQuery
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public SortDirection? SortDirection { get; set; }
        public string? GymCityPhrase { get; set; }
        public string? GymNamePhrase { get; set; }

    }

}
