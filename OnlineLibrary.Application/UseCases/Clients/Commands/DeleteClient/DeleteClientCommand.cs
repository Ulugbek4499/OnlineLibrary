using MediatR;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Clients.Commands.DeleteClient
{
    public record DeleteClientCommand(int Id) : IRequest;

    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteClientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            Client Client = await _context.Clients.FindAsync(request.Id)
               ?? throw new NotFoundException(nameof(Client), request.Id);

            _context.Clients.Remove(Client);

            await _context.SaveChangesAsync();
        }
    }

}
