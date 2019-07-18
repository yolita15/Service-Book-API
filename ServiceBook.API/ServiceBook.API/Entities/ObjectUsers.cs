using System;

namespace SB.API.Entities
{
    public class ObjectUsers
    {
        public Guid ObjectId { get; set; }

        public Object Object { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
