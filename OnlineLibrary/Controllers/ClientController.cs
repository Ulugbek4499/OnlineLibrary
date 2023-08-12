using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Application.UseCases.Clients.Commands.CreateClient;
using OnlineLibrary.Application.UseCases.Clients.Commands.DeleteClient;
using OnlineLibrary.Application.UseCases.Clients.Commands.UpdateClient;
using OnlineLibrary.Application.UseCases.Clients.Queries.GetAllClients;
using OnlineLibrary.Application.UseCases.Clients.Queries.GetByIdClient;
using OnlineLibrary.Application.UseCases.Clients.Response;
using X.PagedList;

namespace OnlineLibrary.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : BaseApiController
{
    [HttpPost("[action]")]
    public async ValueTask<int> CreateClient(CreateClientCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("[action]")]
    public async ValueTask<ClientResponse> GetClientById(int Id)
    {
        return await _mediator.Send(new GetByIdClientQuery(Id));
    }

    [HttpGet("[action]")]
    public async ValueTask<IEnumerable<ClientResponse>> GetAllClients(int page = 1)
    {
        IPagedList<ClientResponse> query = (await _mediator
           .Send(new GetAllClientesQuery()))
           .ToPagedList(page, 10);
        return query;
    }

    [HttpPut("[action]")]
    public async ValueTask<IActionResult> UpdateClient(UpdateClientCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async ValueTask<IActionResult> DeleteClient(DeleteClientCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
