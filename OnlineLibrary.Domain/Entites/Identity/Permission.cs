using System.Text.Json.Serialization;
using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites.Identity
{
    public class Permission : BaseAuditableEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Role>? Roles { get; set; }
    }
}
