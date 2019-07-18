﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SB.API.Entities
{
    public class ObjectType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}