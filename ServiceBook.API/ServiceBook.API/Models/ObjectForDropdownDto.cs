using ServiceBook.API.Entities;
using System;

namespace ServiceBook.API.Models
{
    public class ObjectForDropdownDto
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string Name { get; set; }

        public Guid TypeId { get; set; }

        public ObjectType Type { get; set; }

        public Guid TfmId { get; set; }

        public TfmDto Tfm  { get; set; }
    }
}
