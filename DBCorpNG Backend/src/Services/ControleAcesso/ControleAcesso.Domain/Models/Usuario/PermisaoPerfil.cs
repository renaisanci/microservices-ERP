using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.Domain.Model
{
	public class PermisaoPerfil : BaseModel
	{
		public int PerfilId { get; set; }
		public virtual Perfil Perfil { get; set; }
		public int MenuControleId { get; set; }
		public virtual MenuControle MenuElementoControle { get; set; }
	}
}
