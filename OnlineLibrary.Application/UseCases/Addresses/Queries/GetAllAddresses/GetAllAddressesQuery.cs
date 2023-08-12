using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Addresses.Response;

namespace OnlineLibrary.Application.UseCases.Addresses.Queries.GetAllAddress;

public record GetAllAddressesQuery : IRequest<IEnumerable<AddressResponse>>;

public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllAddressesQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<AddressResponse>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var Addresses = await _context.Addresses.ToListAsync();

        return _mapper.Map<IEnumerable<AddressResponse>>(Addresses);
    }
}


