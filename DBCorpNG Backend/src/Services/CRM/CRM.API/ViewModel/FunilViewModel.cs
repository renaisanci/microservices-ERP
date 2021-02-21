
using DBCorp.Infrastructure.Services.Core.ViewModel;
using System.Collections.Generic;

namespace DBCorp.CRM.API.ViewModel
{
    public class FunilViewModel : BaseViewModel
    {
 
        public string Titulo { get; set; }
        public int TotalEtapas { get; set; }
        public IList<EtapaViewModel> Etapas { get; set; }
        public string EtapasLink { get; set; }
        public bool Default { get; set; }

    }
}
