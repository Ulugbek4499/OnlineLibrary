﻿using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites;

public class Client : BaseAuditableEntity
{
    public string Name { get; set; }

    public virtual Address Address { get; set; }
    public virtual ICollection<Book> Books { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}
