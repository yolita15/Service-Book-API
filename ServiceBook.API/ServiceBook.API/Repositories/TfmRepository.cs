using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBook.API.Repositories
{
    public class TfmRepository : IRepository<Tfm>, ITfmRepository
    {
        private ServiceBookContext _context;

        public TfmRepository(ServiceBookContext context)
        {
            _context = context;
        }
        public void Create(Tfm entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tfm entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tfm> GetAll()
        {
            return _context.Tfms;
        }

        public Tfm GetById(Guid id)
        {
            return _context.Tfms.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Tfm entity)
        {
            throw new NotImplementedException();
        }
    }
}
