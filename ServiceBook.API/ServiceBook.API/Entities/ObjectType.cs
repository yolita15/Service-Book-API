using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceBook.API.Entities
{
    public class ObjectType : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
