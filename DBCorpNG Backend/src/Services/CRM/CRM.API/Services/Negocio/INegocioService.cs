using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DBCorp.CRM.API.Services.Negocio
{
   public  interface INegocioService
    {



        IEnumerable<Domain.Models.NegocioAggregation.Negocio> GetAll();
        IEnumerable<Domain.Models.NegocioAggregation.Negocio> GetFunil(string titulo);
        Domain.Models.NegocioAggregation.Negocio GetById(int id);
        Domain.Models.NegocioAggregation.Negocio Create(Domain.Models.NegocioAggregation.Negocio negocio);
        void Update(Domain.Models.NegocioAggregation.Negocio funil);
        void Delete(int id);
    }
}
