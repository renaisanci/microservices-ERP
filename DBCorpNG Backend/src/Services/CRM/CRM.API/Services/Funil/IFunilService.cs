
using System.Collections.Generic;


namespace DBCorp.CRM.API.Services.Funil
{
    public interface IFunilService
    {

        IEnumerable<Domain.Models.FunilAggregation.Funil> GetAll();
        IEnumerable<Domain.Models.FunilAggregation.Funil> GetFunil(string titulo);
        Domain.Models.FunilAggregation.Funil GetById(int id);
        Domain.Models.FunilAggregation.Funil Create(Domain.Models.FunilAggregation.Funil funil);
        void Update(Domain.Models.FunilAggregation.Funil funil);
        void Delete(int id);


    }
}
