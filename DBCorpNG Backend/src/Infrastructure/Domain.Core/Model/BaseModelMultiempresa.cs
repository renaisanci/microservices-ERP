using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.Infrastructure.Domain.Core.Model.EmpresaAggregation;

namespace DBCorp.Infrastructure.Domain.Core.Model
{
	public class BaseModelMultiempresa : BaseModel
	{
		public Empresa Empresa { get; set; }
		public int EmpresaId { get; set; }
	}
}
