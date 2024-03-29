﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceBook.API.Entities
{
    public class Company : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(200)]
        public string Website { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrganizationNumber { get; set; }

        public string ImageName { get; set; }

        [ForeignKey("CustomerId")]
        public User Customer { get; set; }

        public Guid CustomerId { get; set; }
        
        public List<Provider> Providers { get; set; }

        public Company()
        {
            Providers = new List<Provider>();
        }
    }
}
