using FluentValidation;

namespace OnlineLibrary.Application.UseCases.Books.Commands.CreateBook;
public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
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
