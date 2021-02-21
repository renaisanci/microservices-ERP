using DBCorp.Infrastructure.Services.Core.ViewModel;

namespace DBCorp.Infraestrutura.API.ViewModel
{
	public partial class PessoaFisicaViewModel : BaseViewModel
	{
		public string Nome { get; set; }

		public string Sobrenome { get; set; }

		//[JsonProperty(PropertyName = "CPF")]
		public string Cpf { get; set; }	

		//[JsonProperty(PropertyName = "RG")]
		public object Rg { get; set; }

		//[JsonProperty(PropertyName = "Data Nascimento")]
		public string DtNascimento { get; set; }
	}
}
