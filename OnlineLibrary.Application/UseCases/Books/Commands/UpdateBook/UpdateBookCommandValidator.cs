using FluentValidation;

namespace OnlineLibrary.Application.UseCases.Books.Commands.UpdateBook;
public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty()
           .NotNull()
           .WithMessage("Book id is required.");

        RuleFor(d => d.Author)
             .NotEmpty()
             .MaximumLength(100)
             .WithMessage("Author is required");

        RuleFor(d => d.Title)
           .NotEmpty()
           .MaximumLength(100)
           .WithMessage("Title is required");
    }
}
