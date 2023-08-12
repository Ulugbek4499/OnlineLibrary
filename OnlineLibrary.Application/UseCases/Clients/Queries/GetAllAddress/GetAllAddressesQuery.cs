using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Addresses.Response;

namespace OnlineLibrary.Application.UseCases.Addresses.Queries.GetAllAddresses;

public record GetAllAddressesQuery : IRequest<IEnumerable<BookResponse>>;

public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<BookResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllAddressesQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<BookResponse>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var Addresses = await _context.Addresses.ToListAsync();

        return _mapper.Map<IEnumerable<BookResponse>>(Addresses);
    }
}


