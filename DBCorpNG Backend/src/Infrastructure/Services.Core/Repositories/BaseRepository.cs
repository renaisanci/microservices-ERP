using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DBCorp.Infrastructure.Domain.Core.Model;
using DBCorp.Infrastructure.Services.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DBCorp.Infrastructure.Services.Core.Repositories
{
	public class BaseRepository<TModel, TDbContext> : IBaseRepository<TModel, TDbContext> where TModel : class, IBaseModel, new()
																						  where TDbContext : DbContext
	{
		private readonly IUnitOfWork<TDbContext> _unitOfWork;

		public BaseRepository(IUnitOfWork<TDbContext> unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public virtual IQueryable<TModel> GetAll()
		{
			return _unitOfWork.DbContext.Set<TModel>();
		}

		public virtual IQueryable<TModel> All => GetAll();

		public virtual IQueryable<TModel> AllIncluding(params Expression<Func<TModel, object>>[] includeProperties)
		{
			IQueryable<TModel> query = _unitOfWork.DbContext.Set<TModel>();
			return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}

		public virtual TModel GetSingle(int id)
		{
			return this.FirstOrDefault(x => x.Id == id);
		}

		public TModel FirstOrDefault(Expression<Func<TModel, bool>> predicate)
		{
			return All.FirstOrDefault(predicate);
		}

		public virtual IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
		{
			return All.Where(predicate);
		}

		public virtual void Add(TModel entity)
		{
			_unitOfWork.DbContext.Set<TModel>().Add(entity);
		}

		public virtual void Edit(TModel entity)
		{

  
		   /// _unitOfWork.DbContext.Set<TModel>().Attach(entity);
            _unitOfWork.DbContext.Entry(entity).State = EntityState.Modified;
        }

 

        public void Delete(TModel entity)
		{

            _unitOfWork.DbContext.Entry(entity).State = EntityState.Deleted;
            //         TModel existing = _unitOfWork.DbContext.Set<TModel>().Find(entity);
            //if (existing != null) _unitOfWork.DbContext.Set<TModel>().Remove(existing);
        }

		public virtual void DeleteAll(IEnumerable<TModel> entities)
		{
			foreach (var entity in entities)
			{
				this.Delete(entity);
			}
		}

		public virtual void AddAll(IEnumerable<TModel> entities)
		{
			foreach (var entity in entities)
			{
				_unitOfWork.DbContext.Set<TModel>().Add(entity);
			}
		}
	}
}
