using OnlineLibrary.Application.UseCases.Clients.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Addresses.Response;
public class AddressResponse
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public ClientResponse Client { get; set; }
}
