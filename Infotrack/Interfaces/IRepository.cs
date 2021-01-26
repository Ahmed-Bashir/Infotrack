using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infotrack.Interfaces

{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntity(TEntity id);
        IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, object>> predicate);

        IEnumerable<TEntity> GetEntities();

        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);

        Task<TEntity> Delete(int id);
    }
}
