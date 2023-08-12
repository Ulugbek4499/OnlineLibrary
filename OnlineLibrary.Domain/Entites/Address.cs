using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary.Domain.Commons;

namespace OnlineLibrary.Domain.Entites
{
    public class Address:BaseAuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
    }
}
