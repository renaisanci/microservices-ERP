using DBCorp.Infrastructure.Services.Core.ViewModel;
using System;


namespace DBCorp.CRM.API.ViewModel
{
    public class NegocioViewModel : BaseViewModel
    {
        public int FunilEtapaId { get; set; }
        public string Titulo { get; set; }
        public int PessoaIdOrganizacao { get; set; } 
        public int PessoaIdContato { get; set; } 
        public int RepresentanteId { get; set; }
        public decimal ValorNegocio { get; set; }       
        public DateTime? DataFechamentoEsperada { get; set; }


        //recebe data em string no mapeamento joga para DataFechamentoEsperada
        public string DataFechamento { get; set; }
    }
}
