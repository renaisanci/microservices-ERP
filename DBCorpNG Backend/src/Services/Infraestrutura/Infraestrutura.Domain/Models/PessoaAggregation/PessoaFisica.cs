using System;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.Domain.Model
{
	public class PessoaFisica : BaseModel
    {
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime? DataNascimento { get; set; }
 
    }
}
