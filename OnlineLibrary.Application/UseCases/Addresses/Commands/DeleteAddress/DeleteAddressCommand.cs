using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entities;
using MediatR;
using OnlineLibrary.Application.Common.Exceptions;

namespace OnlineLibrary.Application.UseCases.AddressesType.Commands.DeleteAddress;

public class DeleteAddressCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        Address address = await _context.Addresses.FindAsync(request.Id);
        if (address == null)
        {
            throw new NotFoundException(nameof(address), request.Id);
        }
        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
    }

}

