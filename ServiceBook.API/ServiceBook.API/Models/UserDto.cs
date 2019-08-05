using ServiceBook.API.Entities;
using System;

namespace ServiceBook.API.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
       
        public UserType Type { get; set; }

        public Guid TypeId { get; set; }
    }
}
