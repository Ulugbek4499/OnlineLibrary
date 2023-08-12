using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Application.UseCases.Books.Commands.CreateBook;
using OnlineLibrary.Application.UseCases.Books.Commands.DeleteBook;
using OnlineLibrary.Application.UseCases.Books.Commands.UpdateBook;
using OnlineLibrary.Application.UseCases.Books.Queries.GetAllBooks;
using OnlineLibrary.Application.UseCases.Books.Queries.GetByIdBook;
using OnlineLibrary.Application.UseCases.Books.Response;
using X.PagedList;

namespace OnlineLibrary.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : BaseApiController
{
    [HttpPost("[action]")]
    public async ValueTask<int> CreateBook(CreateBookCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("[action]")]
    public async ValueTask<BookResponse> GetBookById(int Id)
    {
        return await _mediator.Send(new GetByIdBookQuery(Id));
    }

    [HttpGet("[action]")]
    public async ValueTask<IEnumerable<BookResponse>> GetAllBooks(int page = 1)
    {
        IPagedList<BookResponse> query = (await _mediator
           .Send(new GetAllBookesQuery()))
           .ToPagedList(page, 10);
        return query;
    }

    [HttpPut("[action]")]
    public async ValueTask<IActionResult> UpdateBook(UpdateBookCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async ValueTask<IActionResult> DeleteBook(DeleteBookCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
