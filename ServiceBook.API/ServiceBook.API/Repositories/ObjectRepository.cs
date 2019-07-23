using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBook.API.Entities;

namespace ServiceBook.API.Repositories
{
    public class ObjectRepository : IRepository<Entities.Object>, IObjectRepository
    {
        private ServiceBookContext _context;

        public ObjectRepository(ServiceBookContext context)
        {
            _context = context;
        }
        public void Create(Entities.Object entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entities.Object entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Object> GetAll()
        {
            return _context.Objects;
        }

        public Entities.Object GetById(Guid objectId)
        {
            return _context.Objects.FirstOrDefault(c => c.Id == objectId);
        }

        public void Update(Entities.Object entity)
        {
            throw new NotImplementedException();
        }
    }
}
