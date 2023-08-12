using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace MarketManager.Application.UseCases.Addresss.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<int>
    {

        public int? ClientId { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
    }
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateAddressCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;

            _context = context;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);
            await _context.Addresses.AddAsync(address, cancellationToken);
            await _context.SaveChangesAsync();

            return address.Id;
        }
    }
}
