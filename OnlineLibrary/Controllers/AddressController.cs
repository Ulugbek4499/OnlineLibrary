using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Application.UseCases.Addresses.Commands.CreateAddress;
using OnlineLibrary.Application.UseCases.Addresses.Commands.DeleteAddress;
using OnlineLibrary.Application.UseCases.Addresses.Commands.UpdateAddress;
using OnlineLibrary.Application.UseCases.Addresses.Queries.GetAllAddress;
using OnlineLibrary.Application.UseCases.Addresses.Queries.GetByIdAddress;
using OnlineLibrary.Application.UseCases.Addresses.Response;
using X.PagedList;

namespace OnlineLibrary.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : BaseApiController
{
    [HttpPost("[action]")]
    public async ValueTask<int> CreateAddress(CreateAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("[action]")]
    public async ValueTask<AddressResponse> GetAddressById(int Id)
    {
        return await _mediator.Send(new GetByIdAddressQuery(Id));
    }

    [HttpGet("[action]")]
    public async ValueTask<IEnumerable<AddressResponse>> GetAllAddresss(int page = 1)
    {
        IPagedList<AddressResponse> query = (await _mediator
           .Send(new GetAllAddressesQuery()))
           .ToPagedList(page, 10);
        return query;
    }

    [HttpPut("[action]")]
    public async ValueTask<IActionResult> UpdateAddress(UpdateAddressCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async ValueTask<IActionResult> DeleteAddress(DeleteAddressCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
