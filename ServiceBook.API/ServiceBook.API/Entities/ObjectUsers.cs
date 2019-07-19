using System;

namespace ServiceBook.API.Entities
{
    public class ObjectUser
    {
        public Guid ObjectId { get; set; }

        public Object Object { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
