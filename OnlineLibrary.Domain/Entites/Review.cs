using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites
{
    public class Review:BaseAuditableEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
