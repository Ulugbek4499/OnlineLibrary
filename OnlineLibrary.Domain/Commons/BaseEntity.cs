using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.Domain.Commons;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}
