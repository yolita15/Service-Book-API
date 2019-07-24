using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBook.API.Models
{
    public class ProviderDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<DepartmentDto> Departments { get; set; }

        public ProviderDto()
        {
            Departments = new List<DepartmentDto>();
        }
    }
}
