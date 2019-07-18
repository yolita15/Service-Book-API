using System;
using System.ComponentModel.DataAnnotations;

namespace SB.API.Entities
{
    public class Tfm
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
