using FluentValidation;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Validators
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
