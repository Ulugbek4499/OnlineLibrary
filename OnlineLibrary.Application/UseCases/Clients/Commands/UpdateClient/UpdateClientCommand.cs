using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;

namespace OnlineLibrary.Application.UseCases.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateClientCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            Client? client = await _context.Clients.FindAsync(request.Id)
               ?? throw new NotFoundException(nameof(client), request.Id);

            _mapper.Map(client, request);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
