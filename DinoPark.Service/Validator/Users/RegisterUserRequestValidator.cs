using DinoPark.Service.Controllers.Users.Entities;
using FluentValidation;

namespace DinoPark.Service.Validator.Users;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
     public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email address is required")
            .EmailAddress()
            .WithMessage("Email address is invalid")
            .MaximumLength(255)
            .WithMessage("Email must be less than 255 characters");
        
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required")
            .Matches(@"^8\d{10}$")
            .WithMessage("Phone number is invalid");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("Login is required")
            .MaximumLength(50)
            .WithMessage("Login must be less than 50 characters");
        
        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("Password is required")
            .MaximumLength(50)
            .WithMessage("Password must be less than 255 characters");
    }
}