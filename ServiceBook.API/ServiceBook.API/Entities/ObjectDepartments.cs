using System;

namespace SB.API.Entities
{
    public class ObjectDepartments
    {
        public Guid ObjectId { get; set; }

        public Object Object { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
