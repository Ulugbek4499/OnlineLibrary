using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Addresses.Response;
public class BookResponse
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public Client Client { get; set; }
}
