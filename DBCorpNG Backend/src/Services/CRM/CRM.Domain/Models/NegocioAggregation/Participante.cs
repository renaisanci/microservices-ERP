using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.CRM.Domain.Models.NegocioAggregation
{
	public class Participante : BaseModel
	{
		public Pessoa Pessoa { get; set; }
		public long PessoaId { get; set; }
	}
}
