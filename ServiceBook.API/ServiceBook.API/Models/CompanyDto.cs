﻿using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBook.API.Models
{
    public class CompanyDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }

        public string OrganizationNumber { get; set; }

        public string ImageUrl { get; set; }

        public UserDto Customer { get; set; }

        public Guid CustomerId { get; set; }

        public List<Provider> Providers { get; set; }
    }
}
