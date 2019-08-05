using System;

namespace ServiceBook.API.Models
{
    public class TfmDto
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string DataToDisplay { get; set; }
    }
}
