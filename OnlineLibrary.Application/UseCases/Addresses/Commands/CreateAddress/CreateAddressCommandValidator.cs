using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace OnlineLibrary.Application.UseCases.Addresses.Commands.CreateAddressesType;
public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(t => t.AddressTypeId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Address Type id is required.");

        RuleFor(d => d.Name)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Name is required");

        RuleFor(d => d.Description)
            .NotEmpty()
            .MaximumLength(250)
            .WithMessage("Description is required");

        RuleFor(d => d.Barcode)
           .NotEmpty()
           .MaximumLength(250)
           .WithMessage("Barcode is required");

        RuleFor(d => d.MeasureType)
            .IsInEnum()
            .WithMessage("Invalid MeasureType");
    }
}
}
