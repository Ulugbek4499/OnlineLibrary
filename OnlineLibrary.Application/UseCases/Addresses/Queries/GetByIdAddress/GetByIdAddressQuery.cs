using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Addresses.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Addresses.Queries.GetByIdAddress;

public record GetByIdAddressQuery(int Id) : IRequest<AddressResponse>;

public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, AddressResponse>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetByIdAddressQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<AddressResponse> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        var Address = FilterIfAddressExsists(request.Id);

        var result = _mapper.Map<AddressResponse>(Address);
        return result;
    }

    private Address FilterIfAddressExsists(int id)
        => _context.Addresses.Find(id)
                 ?? throw new NotFoundException(
                        " There is no Address with this Id. ");

}
