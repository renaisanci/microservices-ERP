using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.Domain.Model
{
	public class PerfilUsuario : BaseModel
	{
		public int UsuarioId { get; set; }
		public virtual Usuario Usuario { get; set; }
		public int PerfilId { get; set; }
		public virtual Perfil Perfil { get; set; }
	}
}
