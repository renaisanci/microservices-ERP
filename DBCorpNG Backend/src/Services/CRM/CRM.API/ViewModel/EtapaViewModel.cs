using DBCorp.Infrastructure.Services.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCorp.CRM.API.ViewModel
{
    public class EtapaViewModel : BaseViewModel
    {
        public int FunilId { get; set; }
        public string Nome { get; set; }
        public int Ordem { get; set; }
        public IList<NegocioViewModel> Negocios { get; set; }

    }
}
