using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites;

public class Address : BaseAuditableEntity
{
    public int? ClientId { get; set; }
    public Client Client { get; set; }

    public string Street { get; set; }
    public string City { get; set; }
}
