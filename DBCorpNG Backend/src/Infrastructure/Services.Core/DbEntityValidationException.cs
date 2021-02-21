using System;
using System.Runtime.Serialization;

namespace DBCorp.Infrastructure.Services.Core
{
	[Serializable]
	internal class DbEntityValidationException : Exception
	{
		public DbEntityValidationException()
		{
		}

		public DbEntityValidationException(string message) : base(message)
		{
		}

		public DbEntityValidationException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected DbEntityValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}