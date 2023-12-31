﻿using FluentValidation;

namespace OnlineLibrary.Application.UseCases.Addresses.Commands.UpdateAddress;
public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty()
           .NotNull()
           .WithMessage("Address id is required.");

        RuleFor(d => d.City)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("City is required");

        RuleFor(d => d.Street)
            .NotEmpty()
            .MaximumLength(250)
            .WithMessage("Street is required");
    }
}
