using FluentValidation;

namespace OnlineLibrary.Application.UseCases.Reviews.Commands.UpdateReview;

public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty()
           .NotNull()
           .WithMessage("Id id is required.");

        RuleFor(d => d.Content)
                   .NotEmpty()
                   .MaximumLength(500)
                   .WithMessage("Content is required");
    }
}
