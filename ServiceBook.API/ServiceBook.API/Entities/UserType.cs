using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceBook.API.Entities
{
    public class UserType : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
