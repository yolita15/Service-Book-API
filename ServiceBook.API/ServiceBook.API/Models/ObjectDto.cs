using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;

namespace ServiceBook.API.Models
{
    public class ObjectDto
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public Company Company { get; set; }

        public Guid CompanyId { get; set; }

        public ObjectType Type { get; set; }

        public Guid TypeId { get; set; }

        public TfmDto Tfm { get; set; }

        public Guid TfmId { get; set; }

        public string ObjectIdentifier { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IList<ObjectUser> ObjectUsers { get; set; }

        public IList<ObjectDepartment> ObjectDepartments { get; set; }
    }
}
