using DBCorp.Infrastructure.Services.Core.ViewModel;

namespace DBCorp.ControleAcesso.API.ViewModel
{
	public class PerfilUsuarioViewModel : BaseViewModel
	{
		public int PerfilId { get; set; }
		public string DescPerfil { get; set; }
	}
}
