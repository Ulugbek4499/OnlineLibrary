using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Addresses.Response;
public class AddressResponce
{
    public int ClientId { get; set; }

    public string Street { get; set; }
    public string City { get; set; }
    public Client Client { get; set; }
}
