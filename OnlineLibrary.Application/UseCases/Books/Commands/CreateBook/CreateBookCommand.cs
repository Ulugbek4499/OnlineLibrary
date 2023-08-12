using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Published_Date { get; set; }
        public IFormFile Photo { get; set; }
        public int ISBN { get; set; }
    }
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateBookCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;

            _context = context;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book Book = _mapper.Map<Book>(request);
            await _context.Books.AddAsync(Book, cancellationToken);
            await _context.SaveChangesAsync();

            return Book.Id;
        }
    }
}
