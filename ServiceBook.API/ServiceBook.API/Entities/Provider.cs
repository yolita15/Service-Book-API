using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SB.API.Entities
{
    public class Provider
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
