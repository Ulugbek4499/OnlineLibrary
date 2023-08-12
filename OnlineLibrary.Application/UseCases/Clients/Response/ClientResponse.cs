using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary.Application.UseCases.Addresses.Response;
using OnlineLibrary.Application.UseCases.Books.Response;
using OnlineLibrary.Application.UseCases.Reviews.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.UseCases.Clients.Response
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressResponse Address { get; set; }
        public virtual ICollection<BookResponse> Books { get; set; }
        public virtual ICollection<ReviewResponse> Reviews { get; set; }
    }
}
