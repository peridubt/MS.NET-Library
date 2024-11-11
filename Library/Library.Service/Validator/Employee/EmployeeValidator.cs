using FluentValidation;
using Library.Service.Controllers.Entities.Employees;

namespace Library.Service.Validator.Employee;

public class EmployeeValidator : AbstractValidator<RegisterEmployeeRequest>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .Matches(@"[\w_]+")
            .WithMessage("Login is required");
        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("Password is required");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches("[+]7[0-9]{10}")
            .WithMessage("Phone number is required");
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is required");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200)
            .WithMessage("Name is required");
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200)
            .WithMessage("Surname is required");
        RuleFor(x => x.PatronymicName)
            .MinimumLength(0)
            .MaximumLength(200)
            .WithMessage("Patronymic is required");
    }
}