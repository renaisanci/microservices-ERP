using System.Collections.Generic;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.Domain.Model
{
	public class Perfil : BaseModel
	{
		public Perfil()
		{
			PerfilPai = new List<Perfil>();
		}

		public int? PaiId { get; set; }
		public string DescPerfil { get; set; }
		public virtual ICollection<Perfil> PerfilPai { get; set; }
	}
}
