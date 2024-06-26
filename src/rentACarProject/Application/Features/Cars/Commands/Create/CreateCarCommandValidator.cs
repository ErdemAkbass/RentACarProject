using FluentValidation;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        
        RuleFor(c => c.Kilometer).NotEmpty();
        RuleFor(c => c.ModelYear).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.MinFindeksCreditRate).NotEmpty();
        RuleFor(c => c.ModelId).NotEmpty();
    }
}