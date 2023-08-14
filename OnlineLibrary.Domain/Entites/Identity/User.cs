using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites.Identity
{
    public class User : BaseAuditableEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Photo { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

    }
}
