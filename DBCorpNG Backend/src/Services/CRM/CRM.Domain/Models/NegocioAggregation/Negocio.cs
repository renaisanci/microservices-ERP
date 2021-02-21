using System;
using DBCorp.CRM.Domain.Models.FunilAggregation;
 
using DBCorp.Infrastructure.Domain.Core;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.CRM.Domain.Models.NegocioAggregation
{
	public class Negocio : BaseModel, IAggregationRoot
	{
		public FunilEtapa FunilEtapa { get; set; }
		public int FunilEtapaId { get; set; }

		public string Titulo { get; set; }

		public Pessoa Organizacao { get; set; }
		public int? PessoaIdOrganizacao { get; set; }

		public Pessoa Contato { get; set; }
		public int? PessoaIdContato { get; set; }

		public Representante Representante { get; set; }
		public int? RepresentanteId { get; set; }

		public DateTime? DataFechamentoEsperada { get; set; }

		public decimal ValorPrevisto { get; set; }
	}
}
