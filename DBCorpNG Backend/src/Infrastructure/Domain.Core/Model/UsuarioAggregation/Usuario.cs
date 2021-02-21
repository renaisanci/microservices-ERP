using System.ComponentModel.DataAnnotations.Schema;

namespace DBCorp.Infrastructure.Domain.Core.Model
{
	[Table("Usuario", Schema = "ControleAcesso")]
	public class Usuario : BaseModel, IAggregationRoot
	{
		public int PessoaId { get; set; }
		public virtual Pessoa Pessoa { get; set; }
		public string PrimeiroNome { get; set; }
		public string UltimoNome { get; set; }
		public string Username { get; set; }
		public string Token { get; set; }
		public TipoUsuario TipoUsuario { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
	}
}