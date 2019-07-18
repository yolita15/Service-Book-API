using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB.API.Entities
{
    public class Company
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

        [ForeignKey("CustomerId")]
        public User Customer { get; set; }

        public Guid CustomerId { get; set; }

        public IList<CompanyProviders> CompanyProviders { get; set; }
    }
}
