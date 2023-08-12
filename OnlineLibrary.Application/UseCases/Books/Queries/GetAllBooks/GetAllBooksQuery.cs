using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Books.Response;

namespace OnlineLibrary.Application.UseCases.Books.Queries.GetAllBooks;

public record GetAllBookesQuery : IRequest<IEnumerable<BookResponse>>;

public class GetAllBookesQueryHandler : IRequestHandler<GetAllBookesQuery, IEnumerable<BookResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllBookesQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<BookResponse>> Handle(GetAllBookesQuery request, CancellationToken cancellationToken)
    {
        var Bookes = await _context.Books.ToListAsync();

        return _mapper.Map<IEnumerable<BookResponse>>(Bookes);
    }
}


