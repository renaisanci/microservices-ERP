using System;
using System.Collections.Generic;
using System.Text;
using DBCorp.Infrastructure.Domain.Core;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.CRM.Domain.Models.FunilAggregation
{
	public class Funil : BaseModel, IAggregationRoot, IAuditable
	{
		public string Titulo { get; set; }
        public bool Default { get; set; }

        public IList<FunilEtapa> Etapas { get; set; }

		public IList<FunilEmpresa> Empresas { get; set; }
	}
}
