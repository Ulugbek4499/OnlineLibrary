﻿using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.AddressesType.Commands.DeleteAddress;

public record DeleteBookCommand(int Id) : IRequest;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        Address address = await _context.Addresses.FindAsync(request.Id)
           ?? throw new NotFoundException(nameof(address), request.Id);

        _context.Addresses.Remove(address);

        await _context.SaveChangesAsync();
    }
}

