using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCorp.CRM.API.Services.Funil
{
    
    public interface IEtapaService
    {
        IEnumerable<Domain.Models.FunilAggregation.FunilEtapa> GetAll();
        IEnumerable<Domain.Models.FunilAggregation.FunilEtapa> GetByFunilId(int id);
        Domain.Models.FunilAggregation.FunilEtapa GetById(int id);
        Domain.Models.FunilAggregation.FunilEtapa Create(Domain.Models.FunilAggregation.FunilEtapa etapa);
        void Update(Domain.Models.FunilAggregation.FunilEtapa etapa);
        void Delete(int id);
    }

 
}
