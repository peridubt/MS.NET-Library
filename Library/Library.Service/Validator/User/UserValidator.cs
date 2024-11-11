using FluentValidation;
using Library.Service.Controllers.Entities.Users;

namespace Library.Service.Validator.User;

public class UserValidator : AbstractValidator<RegisterUserRequest>
{
    public UserValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .Matches(@"[\w_]+")
            .WithMessage("Login is required");
        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("Password is required");
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is required");
    }
}