using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Books.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Books.Queries.GetByIdBook;

public record GetByIdBookQuery(int Id) : IRequest<BookResponse>;

public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, BookResponse>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetByIdBookQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<BookResponse> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        var Book = FilterIfBookExsists(request.Id);

        var result = _mapper.Map<BookResponse>(Book);
        return result;
    }

    private Book FilterIfBookExsists(int id)
        => _context.Books.Find(id)
                 ?? throw new NotFoundException(
                        " There is no Book with this Id. ");

}
