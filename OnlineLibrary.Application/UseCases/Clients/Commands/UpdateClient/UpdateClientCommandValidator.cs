using FluentValidation;

namespace OnlineLibrary.Application.UseCases.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty()
               .NotNull()
               .WithMessage("Client id is required.");

            RuleFor(d => d.Name)
                 .NotEmpty()
                 .MaximumLength(100)
                 .WithMessage("Name is required");
        }
    }
}
