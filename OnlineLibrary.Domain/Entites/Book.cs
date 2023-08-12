﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites
{
    public class Book:BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Published_Date { get; set; }
        public int ISBN { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
