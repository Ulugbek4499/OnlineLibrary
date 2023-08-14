using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites
{
    public class Review : BaseAuditableEntity
    {
        public int ClientId { get; set; }
        public int BookId { get; set; }

        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }

        public virtual Client Client { get; set; }

        public virtual Book Book { get; set; }
    }
}
