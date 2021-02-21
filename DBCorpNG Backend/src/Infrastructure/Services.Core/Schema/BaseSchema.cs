namespace DBCorp.Infrastructure.Services.Core.Schema
{
	public abstract class BaseSchema
	{
		private string _schemaName;

		public BaseSchema(string schemaName)
		{
			this._schemaName = schemaName;
		}

		public override string ToString()
		{
			return _schemaName;
		}
	}
}
