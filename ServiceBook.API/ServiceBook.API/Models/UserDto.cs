using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBook.API.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
       
        public UserTypeDto Type { get; set; }

        public Guid TypeId { get; set; }
    }
}
