using System.Collections.Generic;
using DBCorp.Infrastructure.Services.Core.ViewModel;

namespace DBCorp.ControleAcesso.API.ViewModel
{
	public class MenuViewModel : BaseViewModel
	{
		public int MenuPaiId { get; set; }
		public int ModuloId { get; set; }
		public string DescMenu { get; set; }
		public int Nivel { get; set; }
		public int Ordem { get; set; }
		public string State { get; set; }
		public string Icon { get; set; }
		public string Type { get; set; }
		public string Badge { get; set; }
		public string BadgeValue { get; set; }
		public List<MenuViewModel> Children { get; set; }
	}
}
