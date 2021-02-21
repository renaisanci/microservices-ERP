using System.Collections.Generic;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.Domain.Model
{
	public class Menu : BaseModel
	{
		public Menu()
		{
			MenuPai = new List<Menu>();
			MenuControles = new List<MenuControle>();
		}

		public int? MenuPaiId { get; set; }
		public virtual Menu MenuFilho { get; set; }
		public int ModuloId { get; set; }
		public virtual Modulo Modulo { get; set; }
		public string DescMenu { get; set; }
		public int Nivel { get; set; }
		public int Ordem { get; set; }
		public string State { get; set; }
		public string Icon { get; set; }
		public string Type { get; set; }
		public string Badge { get; set; }
		public string BadgeValue { get; set; }

		public virtual ICollection<MenuControle> MenuControles { get; set; }
		public virtual ICollection<Menu> MenuPai { get; set; }
	}
}
