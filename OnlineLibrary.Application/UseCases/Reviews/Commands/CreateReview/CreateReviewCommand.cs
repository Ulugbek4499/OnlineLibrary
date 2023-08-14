using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Reviews.Commands.CreateReview;

public class CreateReviewCommand : IRequest<int>
{
    public int ClientId { get; set; }
    public int BookId { get; set; }

    public string Content { get; set; }
    public DateTime PublishedDate { get; set; }
}
public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public CreateReviewCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;

        _context = context;
    }

    public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        Review Review = _mapper.Map<Review>(request);
        await _context.Reviews.AddAsync(Review, cancellationToken);
        await _context.SaveChangesAsync();

        return Review.Id;
    }
}
