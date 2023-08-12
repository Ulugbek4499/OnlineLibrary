using FluentValidation;

namespace OnlineLibrary.Application.UseCases.Addresses.Commands.CreateAddress;
public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(d => d.City)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("City is required");


        RuleFor(d => d.Street)
            .NotEmpty()
            .MaximumLength(250)
            .WithMessage("street is required");
    }
}
