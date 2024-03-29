﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceBook.API.Entities
{
    public class Department : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string ImageName { get; set; }

        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }

        public Guid ProviderId { get; set; }
    }
}
