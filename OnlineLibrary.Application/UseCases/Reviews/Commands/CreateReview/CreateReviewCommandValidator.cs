using FluentValidation;

namespace OnlineLibrary.Application.UseCases.Reviews.Commands.CreateReview;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(d => d.Content)
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("Content is required");

    }
}
