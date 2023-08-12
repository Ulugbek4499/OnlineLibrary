using OnlineLibrary.Application.UseCases.Books.Response;
using OnlineLibrary.Application.UseCases.Clients.Response;

namespace OnlineLibrary.Application.UseCases.Reviews.Response
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }

        public ClientResponse Client { get; set; }

        public BookResponse Book { get; set; }
    }
}
