using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DBCorp.Infrastructure.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace DBCorp.Infrastructure.Services.Core.Repositories
{
	public interface IBaseRepository<TModel, TDbContext> where TModel : class, IBaseModel, new()
														  where TDbContext : DbContext
	{
		IQueryable<TModel> AllIncluding(params Expression<Func<TModel, object>>[] includeProperties);
		IQueryable<TModel> All { get; }
		IQueryable<TModel> GetAll();
		TModel GetSingle(int id);
		TModel FirstOrDefault(Expression<Func<TModel, bool>> predicate);
		IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
		void Add(TModel entity);
		void Delete(TModel entity);
		void DeleteAll(IEnumerable<TModel> entities);
		void AddAll(IEnumerable<TModel> entities);
		void Edit(TModel entity);
		//Task<IList<T>> ExecWithStoreProcedureAsync<T>(string query, params object[] parameters);
		//IEnumerable<T> ExecWithStoreProcedure<T>(string query, params object[] parameters);
		//Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters);
		//void ExecuteWithStoreProcedure(string query, params object[] parameters);
	}
}
