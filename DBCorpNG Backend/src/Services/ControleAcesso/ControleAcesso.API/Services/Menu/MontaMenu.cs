using System.Collections.Generic;
using System.Linq;
using DBCorp.ControleAcesso.API.ViewModel;

namespace DBCorp.ControleAcesso.API.Services.Menu
{
	public class MontaMenu : List<MenuAux>
	{
		public MontaMenu()
		{
		}

		public MontaMenu(List<MenuViewModel> lmenu)
		{
			foreach (var menu in lmenu)
			{
				if (menu.MenuPaiId > 0)
				{
					MenuAux hmpai = this.BuscaMenu(menu.MenuPaiId);
					MenuAux hm = new MenuAux();

					hm.Id = menu.Id;
					hm.State = menu.State;
					hm.DescMenu = menu.DescMenu;
					hm.MenuPaiId = menu.MenuPaiId;
					hm.Icon = menu.Icon;
					hm.Type = menu.Type;
					hm.Badge = menu.Badge;
					hm.BadgeValue = menu.BadgeValue;
					hm.Nivel = menu.Nivel;
					hm.Ordem = menu.Ordem;
					hm.ModuloId = menu.ModuloId;

					hmpai.Children.Add(hm);
				}
				else
				{
					MenuAux hm = new MenuAux();
					hm.Id = menu.Id;
					hm.State = menu.State;
					hm.DescMenu = menu.DescMenu;
					hm.MenuPaiId = menu.MenuPaiId;
					hm.Icon = menu.Icon;
					hm.Type = menu.Type;
					hm.Badge = menu.Badge;
					hm.BadgeValue = menu.BadgeValue;
					hm.Nivel = menu.Nivel;
					hm.Ordem = menu.Ordem;
					hm.ModuloId = menu.ModuloId;

					this.Add(hm);
					this.ToList().OrderBy(p => p.Ordem);
				}
			}

			//return _lHierarquiaMenu;
		}

		public MenuAux BuscaMenu(int menuPaiId)
		{
			return BuscaMenu(this, menuPaiId);
		}

		public MenuAux BuscaMenu(MontaMenu lMenu, int menuPaiId)
		{
			foreach (var menu in lMenu.OrderBy(p => p.Ordem))
			{
				if (menu.Id == menuPaiId)
				{
					return menu;
				}
				else if (menu.Children.Count > 0)
				{
					MenuAux hm = BuscaMenu(menu.Children, menuPaiId);
					if (hm != null)
					{
						return hm;
					}
				}
			}

			return null;
		}
	}
}
