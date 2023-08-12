using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Addresses.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Addresses.Queries.GetByIdAddressQuery;

public record GetByIdAddressQuery(int Id) : IRequest<BookResponse>;

public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, BookResponse>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetByIdAddressQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<BookResponse> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        var Address = FilterIfAddressExsists(request.Id);

        var result = _mapper.Map<BookResponse>(Address);
        return result;
    }

    private Address FilterIfAddressExsists(int id)
        => _context.Addresses.Find(id)
                 ?? throw new NotFoundException(
                        " There is no Address with this Id. ");

}
