using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.CRM.Domain.Models.NegocioAggregation
{
	public class NegocioAtividade : BaseModel
	{
		public Negocio Negocio { get; set; }
		public long NegocioId { get; set; }

		public TipoAtividade TipoAtividade { get; set; }

		public string Titulo { get; set; }

		public string Observacao { get; set; }

		public DateTime DataHora { get; set; }

		public int DuracaoMinutos { get; set; }
	}
}
