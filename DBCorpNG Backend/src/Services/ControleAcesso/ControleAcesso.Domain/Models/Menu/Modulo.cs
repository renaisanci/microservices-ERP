using System.Collections.Generic;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.Domain.Model
{
	public class Modulo : BaseModel
	{
		public Modulo()
		{
			Menus = new List<Menu>();
		}

		public string NomeModulo { get; set; }
		public virtual ICollection<Menu> Menus { get; set; }
	}
}
