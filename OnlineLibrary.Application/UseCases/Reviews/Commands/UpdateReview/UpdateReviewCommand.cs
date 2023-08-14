using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Reviews.Commands.UpdateReview;

public class UpdateReviewCommand : IRequest
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int BookId { get; set; }

    public string Content { get; set; }
    public DateTime PublishedDate { get; set; }
}
public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public UpdateReviewCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        Review? Review = await _context.Reviews.FindAsync(request.Id)
           ?? throw new NotFoundException(nameof(Review), request.Id);

        _mapper.Map(request, Review);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
