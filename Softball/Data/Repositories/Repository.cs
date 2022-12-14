using Microsoft.EntityFrameworkCore;
using Sport.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Sport.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }


        public async Task Add(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }


        public async Task AddRange(IEnumerable<TEntity> entities)
        {
           await _entities.AddRangeAsync(entities);
        }


        public IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate)
        {
            return  _entities.Where(predicate);
        }


        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }


        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }


        public IEnumerable<TEntity> GetAll()
        {
                return _entities.ToList();
        }


        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }


        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }
    }
}
