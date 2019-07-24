using System;

namespace ServiceBook.API.Models
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ProviderDto Provider { get; set; }

        public Guid ProviderId { get; set; }
    }
}