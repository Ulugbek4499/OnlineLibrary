using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Clients.Response;

namespace OnlineLibrary.Application.UseCases.Clients.Queries.GetAllClients
{
    public record GetAllClientesQuery : IRequest<IEnumerable<ClientResponse>>;

    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, IEnumerable<ClientResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllClientesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ClientResponse>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            var Clientes = await _context.Clients.ToListAsync();

            return _mapper.Map<IEnumerable<ClientResponse>>(Clientes);
        }
    }

}
