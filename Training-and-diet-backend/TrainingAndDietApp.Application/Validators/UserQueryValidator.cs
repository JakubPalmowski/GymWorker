using FluentValidation;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.Domain.Entities;
using UserQuery = TrainingAndDietApp.Application.Queries.User.UserQuery;

namespace TrainingAndDietApp.Application.Validators
{
    public class UserQueryValidator : AbstractValidator<UserQuery>
    {
        private string[] allowedSortByColumnNames = {  nameof(User.MentorOpinions) };
        public UserQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");   
        }
    }
}
