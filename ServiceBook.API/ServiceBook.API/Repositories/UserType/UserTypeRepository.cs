using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceBook.API.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private ServiceBookContext _context;

        public UserTypeRepository(ServiceBookContext context)
        {
            _context = context;
        }

        public IEnumerable<UserType> GetAll()
        {
            return _context.UserTypes;
        }

        public UserType GetById(Guid id)
        {
            return _context.UserTypes.FirstOrDefault(u => u.Id == id);
        }
    }
}
