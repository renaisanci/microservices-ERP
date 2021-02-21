using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.CRM.Domain.Models.NegocioAggregation
{
	public class NegocioHistorico : BaseModel
	{
		public Negocio Negocio { get; set; }
		public long NegocioId { get; set; }

		public TipoHistorico TipoHistorico { get; set; }

		public DateTime DataHora { get; set; }
	}
}
