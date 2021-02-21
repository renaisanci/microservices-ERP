using System;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.Domain.Model
{
	public class PessoaJuridica : BaseModel
	{
		public int PessoaId { get; set; }
		public virtual Pessoa Pessoa { get; set; }
		public string NomeFantasia { get; set; }
		public string Cnpj { get; set; }
		public string RazaoSocial { get; set; }
		public string InscEstadual { get; set; }
		public DateTime? DtFundacao { get; set; }
	}
}
