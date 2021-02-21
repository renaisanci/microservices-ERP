using DBCorp.ControleAcesso.API.ViewModel;

namespace DBCorp.ControleAcesso.API.Services.Menu
{
	public class MenuAux : MenuViewModel
	{
		public new MontaMenu Children { get; set; }

		public MenuAux()
		{
			Children = new MontaMenu();
		}
	}
}
