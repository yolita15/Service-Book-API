using System;

namespace ServiceBook.API.Models
{
    public class ObjectForDropdownDto
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string Name { get; set; }
    }
}
