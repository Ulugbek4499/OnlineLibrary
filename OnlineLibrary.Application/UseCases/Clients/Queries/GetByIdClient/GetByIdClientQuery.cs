using AutoMapper;
using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.UseCases.Clients.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Clients.Queries.GetByIdClient
{
    public record GetByIdClientQuery(int Id) : IRequest<ClientResponse>;

    public class GetByIdClientQueryHandler : IRequestHandler<GetByIdClientQuery, ClientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetByIdClientQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ClientResponse> Handle(GetByIdClientQuery request, CancellationToken cancellationToken)
        {
            var Client = FilterIfClientExsists(request.Id);

            var result = _mapper.Map<ClientResponse>(Client);
            return result;
        }

        private Client FilterIfClientExsists(int id)
            => _context.Clients.Find(id)
                     ?? throw new NotFoundException(
                            " There is no client with this Id. ");

    }

}
