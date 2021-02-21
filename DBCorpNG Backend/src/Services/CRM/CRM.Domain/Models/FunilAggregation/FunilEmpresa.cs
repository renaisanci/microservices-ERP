using System.Collections.Generic;
using DBCorp.Infrastructure.Domain.Core.Model;
using DBCorp.Infrastructure.Domain.Core.Model.EmpresaAggregation;

namespace DBCorp.CRM.Domain.Models.FunilAggregation
{
	public class FunilEmpresa : BaseModel
	{
		public Funil Funil { get; set; }
		public int FunilId { get; set; }

		public Empresa Empresa { get; set; }
		public int EmpresaId { get; set; }
	}
}
