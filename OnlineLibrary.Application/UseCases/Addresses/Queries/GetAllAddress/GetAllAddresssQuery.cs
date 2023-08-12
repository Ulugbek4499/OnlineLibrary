using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.Common.Models;
using OnlineLibrary.Application.UseCases.Addresses.Response;
using OnlineLibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Application.UseCases.Addresses.Queries.GetAllAddresses;

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
        IEnumerable<Address> Addresses = await _context.Addresses.ToListAsync();

        return Task.FromResult(_mapper.Map<IEnumerable<AddressResponse>>(Addresses));
    }
}


