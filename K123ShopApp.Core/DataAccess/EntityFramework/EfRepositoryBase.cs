using System;
using System.Linq.Expressions;
using K123ShopApp.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace K123ShopApp.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using var context = new TContext();
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var addRemove = context.Entry(entity);
            addRemove.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();

            return context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            return filter == null
                   ? context.Set<TEntity>().ToList()
                   : context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var addUpdate = context.Entry(entity);
            addUpdate.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

