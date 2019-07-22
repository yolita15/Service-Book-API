using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceBook.API.Entities
{
    public class Provider : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<Department> Departments { get; set; }

        public Provider()
        {
            Departments = new List<Department>();
        }
    }
}
