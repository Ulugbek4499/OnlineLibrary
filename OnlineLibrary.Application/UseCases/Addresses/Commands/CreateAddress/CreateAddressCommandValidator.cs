using FluentValidation;
using MarketManager.Application.UseCases.Addresss.Commands.CreateAddress;

namespace OnlineLibrary.Application.UseCases.Addresses.Commands.CreateAddressesType;
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
