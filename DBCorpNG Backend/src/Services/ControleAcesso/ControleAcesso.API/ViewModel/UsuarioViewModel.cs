using DBCorp.Infrastructure.Services.Core.ViewModel;

namespace DBCorp.ControleAcesso.API.ViewModel
{
	public class UsuarioViewModel : BaseViewModel
	{
		public string PrimeiroNome { get; set; }
		public string UltimoNome { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }
		public int TipoUsuario { get; set; }
	}
}