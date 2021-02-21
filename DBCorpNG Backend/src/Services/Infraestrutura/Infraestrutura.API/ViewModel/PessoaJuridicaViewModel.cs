using DBCorp.Infrastructure.Services.Core.ViewModel;

namespace DBCorp.Infraestrutura.API.ViewModel
{
	public class PessoaJuridicaViewModel : BaseViewModel
	{

		public string NomeFantasia { get; set; }
		public string Cnpj { get; set; }
		// [JsonProperty(PropertyName = "Razão Social")]
		public string RazaoSocial { get; set; }
		public string InscEstadual { get; set; }
		public string DtFundacao { get; set; }
	}
}
