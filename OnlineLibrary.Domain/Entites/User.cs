using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Entites
{
    public class User
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
