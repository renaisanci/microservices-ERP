using System;

namespace DBCorp.Infrastructure.Services.Core.UnitOfWork
{
	public interface IUnitOfWork<TDbContext>
	{
		TDbContext DbContext { get; }
		void Commit();
	}
}
