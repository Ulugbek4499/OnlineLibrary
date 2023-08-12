using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Reviews.Response;

namespace OnlineLibrary.Application.UseCases.Reviews.Queries.GetAllReviews;


public record GetAllReviewesQuery : IRequest<IEnumerable<ReviewResponse>>;

public class GetAllReviewesQueryHandler : IRequestHandler<GetAllReviewesQuery, IEnumerable<ReviewResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllReviewesQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<ReviewResponse>> Handle(GetAllReviewesQuery request, CancellationToken cancellationToken)
    {
        var Reviewes = await _context.Reviews.ToListAsync();

        return _mapper.Map<IEnumerable<ReviewResponse>>(Reviewes);
    }
}
