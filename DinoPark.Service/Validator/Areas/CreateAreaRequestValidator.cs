using DinoPark.Service.Controllers.Areas.Entities;
using FluentValidation;

namespace DinoPark.Service.Validator.Areas;

public class CreateAreaRequestValidator : AbstractValidator<CreateAreaRequest>
{
    public CreateAreaRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must be less than 50 characters");
        
        RuleFor(x => x.DangerLevel)
            .NotEmpty()
            .WithMessage("Danger level is required")
            .GreaterThan(0)
            .WithMessage("Danger level must be greater than 0");
        
        RuleFor(x => x.Square)
            .NotEmpty()
            .WithMessage("Square is required")
            .GreaterThan(0)
            .WithMessage("Square must be greater than 0");
    }
}