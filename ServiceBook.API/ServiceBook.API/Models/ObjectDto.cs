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

        public string Comment { get; set; }

        public string ImageName { get; set; }

        public string Path { get; set; }

        public Company Company { get; set; }

        public Guid CompanyId { get; set; }

        public ObjectType Type { get; set; }

        public Guid TypeId { get; set; }

        public TfmDto Tfm { get; set; }

        public Guid TfmId { get; set; }

        public string ObjectIdentifier { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IEnumerable<UserDto> Users { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
