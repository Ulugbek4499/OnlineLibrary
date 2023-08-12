using OnlineLibrary.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using OnlineLibrary.Application.Common.Exceptions;

namespace OnlineLibrary.Application.UseCases.AddressesType.Commands.UpdateAddress;

public class UpdateAddressCommand : IRequest
{
    public Guid Id { get; set; }
    public int? ClientId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
}
public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public UpdateAddressCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        Address? address = await _context.Addresss.FindAsync(request.Id);
        _mapper.Map(address, request);

        if (address is null)
            throw new NotFoundException(nameof(address), request.Id);

        var AddressType = await _context.AddressTypes.FindAsync(request.AddressTypeId);

        if (AddressType is null)
            throw new NotFoundException(nameof(AddressType), request.AddressTypeId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
