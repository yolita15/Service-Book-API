using ServiceBook.API.Entities;
using System;
using System.Collections.Generic;

namespace ServiceBook.API.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);
    }
}
