using System;

namespace ServiceBook.API.Entities
{
    public class ObjectDepartment
    {
        public Guid ObjectId { get; set; }

        public Object Object { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
