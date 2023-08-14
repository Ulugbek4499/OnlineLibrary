using System.Text.Json.Serialization;
using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites.Identity
{
    public class Role : BaseAuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Permission>? Permissions { get; set; }

        [JsonIgnore]
        public virtual ICollection<User>? Users { get; set; }

    }
}
