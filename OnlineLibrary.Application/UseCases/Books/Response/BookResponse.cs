using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Books.Response;
public class BookResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime Published_Date { get; set; }
    public string Photo { get; set; }
    public int ISBN { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Client> Clients { get; set; }
}
