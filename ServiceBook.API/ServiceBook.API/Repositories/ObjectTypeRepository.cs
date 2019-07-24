using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBook.API.Repositories
{
    public class ObjectTypeRepository : IRepository<ObjectType>, IObjectTypeRepository
    {
        private ServiceBookContext _context;

        public ObjectTypeRepository(ServiceBookContext context)
        {
            _context = context;
        }

        public void Create(ObjectType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ObjectType entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjectType> GetAll()
        {
            return _context.ObjectTypes;
        }

        public ObjectType GetById(Guid id)
        {
            return _context.ObjectTypes.FirstOrDefault(o => o.Id == id);
        }

        public void Update(ObjectType entity)
        {
            throw new NotImplementedException();
        }
    }
}
