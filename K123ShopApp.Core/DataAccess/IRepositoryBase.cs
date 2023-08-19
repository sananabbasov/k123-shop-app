using System;
using System.Linq.Expressions;
using K123ShopApp.Core.Entities.Abstract;

namespace K123ShopApp.Core.DataAccess
{
	public interface IRepositoryBase<TEntity>
		where TEntity : class, IEntity
	{
		void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
		TEntity Get(Expression<Func<TEntity, bool>> filter);
		List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
	}
}

