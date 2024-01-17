using FluentValidation;
using TrainingAndDietApp.Domain.Entities;
using UserQuery = TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll.UserQuery;

namespace TrainingAndDietApp.Application.CQRS.Validators
{
    public class UserQueryValidator : AbstractValidator<UserQuery>
    {
        private readonly string[] _allowedSortByColumnNames = { nameof(User.MentorOpinions), "DietPrice", "TrainingPrice", "PlanPrice" };
        public UserQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.SortBy).Must(value => string.IsNullOrEmpty(value) || _allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", _allowedSortByColumnNames)}]");
        }
    }
}
