using AutoMapper;
using OnlineLibrary.Application.UseCases.Books.Commands.CreateBook;
using OnlineLibrary.Application.UseCases.Books.Commands.DeleteBook;
using OnlineLibrary.Application.UseCases.Books.Commands.UpdateBook;
using OnlineLibrary.Application.UseCases.Books.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.Common.Mapping;

public class BookMapping : Profile
{
    public BookMapping()
    {
        CreateMap<CreateBookCommand, Book>();
        CreateMap<DeleteBookCommand, Book>();
        CreateMap<UpdateBookCommand, Book>();
        CreateMap<Book, BookResponse>();
    }
}
