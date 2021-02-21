using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.CRM.Domain.Models.NegocioAggregation
{
	public class NegocioSeguidor : BaseModel
	{
		public Negocio Negocio { get; set; }
		public long NegocioId { get; set; }

		public Pessoa Seguidor { get; set; }
		public long PessoaIdSeguidor { get; set; }
	}
}
