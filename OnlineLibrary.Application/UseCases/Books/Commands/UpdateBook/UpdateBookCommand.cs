using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineLibrary.Application.Common.Exceptions;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Books.Commands.UpdateBook;

public class UpdateBookCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime Published_Date { get; set; }
    public IFormFile? Photo { get; set; }
    public int ISBN { get; set; }
}
public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public UpdateBookCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        Book? Book = await _context.Books.FindAsync(request.Id)
           ?? throw new NotFoundException(nameof(Book), request.Id);

        _mapper.Map(request, Book);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
