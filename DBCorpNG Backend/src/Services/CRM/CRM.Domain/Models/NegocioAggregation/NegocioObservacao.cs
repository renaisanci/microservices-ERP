using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.CRM.Domain.Models.NegocioAggregation
{
	public class NegocioObservacao : BaseModel
	{
		public Negocio Negocio { get; set; }
		public long NegocioId { get; set; }

		public Participante Participante { get; set; }
		public long ParticipanteId { get; set; }

		public DateTime DataHora { get; set; }

		public string Observacao { get; set; }
	}
}
