using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Reviews.Commands.DeleteReview;


public record DeleteReviewCommand(int Id) : IRequest;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteReviewCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        Review Review = await _context.Reviews.FindAsync(request.Id)
           ?? throw new NotFoundException(nameof(Review), request.Id);

        _context.Reviews.Remove(Review);

        await _context.SaveChangesAsync();
    }
}
