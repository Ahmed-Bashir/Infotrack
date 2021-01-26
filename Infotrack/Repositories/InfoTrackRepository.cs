using Infotrack.Interfaces;
using Infotrack.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infotrack.Repositories
{
    public class InfoTrackRepository<TEntity> : IRepository<TEntity> where TEntity: class 
    {
        private readonly AppDbContext  _context;
        private readonly DbSet<TEntity> _dbSet;
        public InfoTrackRepository(AppDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
              await  _context.SaveChangesAsync();

            }

            return entity;
        }

       
        public IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, object>> predicate)
        {

            return _dbSet.Include(predicate).ToList();
        }

        public IEnumerable<TEntity> GetEntities()
        {
           return _dbSet.ToList();
        }

        public async Task<TEntity> GetEntity(TEntity id)
        {
            
            
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public  TEntity Update(TEntity entityChanges)
        {
            var entity =_dbSet.Attach(entityChanges);

           _context.Update(entity);

            return entityChanges;
            
        }

       
    }
}
