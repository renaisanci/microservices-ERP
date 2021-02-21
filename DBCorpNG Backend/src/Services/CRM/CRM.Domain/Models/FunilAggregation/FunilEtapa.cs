using DBCorp.CRM.Domain.Models.NegocioAggregation;
using DBCorp.Infrastructure.Domain.Core.Model;
using System.Collections.Generic;

namespace DBCorp.CRM.Domain.Models.FunilAggregation
{
	public class FunilEtapa : BaseModel
	{
		public Funil Funil { get; set; }
		public int FunilId { get; set; }

		public string Nome { get; set; }

		public short Ordem { get; set; }

        public IList<Negocio> Negocios { get; set; }
    }
}
