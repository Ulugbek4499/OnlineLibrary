using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Reviews.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Reviews.Queries.GetByIdReview;


public record GetByIdReviewQuery(int Id) : IRequest<ReviewResponse>;

public class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQuery, ReviewResponse>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetByIdReviewQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ReviewResponse> Handle(GetByIdReviewQuery request, CancellationToken cancellationToken)
    {
        var Review = FilterIfReviewExsists(request.Id);

        var result = _mapper.Map<ReviewResponse>(Review);
        return result;
    }

    private Review FilterIfReviewExsists(int id)
        => _context.Reviews.Find(id)
                 ?? throw new NotFoundException(
                        " There is no Review with this Id. ");

}
