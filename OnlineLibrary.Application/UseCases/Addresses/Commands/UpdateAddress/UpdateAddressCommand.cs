using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Addresses.Commands.UpdateAddress;

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
        Address? address = await _context.Addresses.FindAsync(request.Id)
           ?? throw new NotFoundException(nameof(address), request.Id);

        _mapper.Map(address, request);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
