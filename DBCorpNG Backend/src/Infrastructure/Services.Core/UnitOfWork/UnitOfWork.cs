using Microsoft.EntityFrameworkCore;

namespace DBCorp.Infrastructure.Services.Core.UnitOfWork
{
	public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
	{
		public TDbContext DbContext { get; }

		public UnitOfWork(TDbContext context)
		{
			DbContext = context;
		}
		public void Commit()
		{
			DbContext.SaveChanges();
		}

		public void Dispose()
		{
			DbContext.Dispose();
		}
	}
}
