using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBook.API.Models
{
    public class ObjectDto
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }
    }
}
