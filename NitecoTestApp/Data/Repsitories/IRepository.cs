using NitecoTestApp.Data.Entities;
using NitecoTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Data.Repsitories
{
public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        TEntity Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
