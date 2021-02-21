using System;
using System.Collections.Generic;

namespace DBCorp.Infrastructure.Domain.Core.Model
{
	public abstract class BaseModel : IBaseModel
	{
		public int Id { get; set; }

		public virtual Usuario UsuarioCriacao { get; set; }
		public int? UsuarioCriacaoId { get; set; }

		public DateTime DataHoraCriacao { get; set; }

		public virtual Usuario UsuarioAlteracao { get; set; }
		public int? UsuarioAlteracaoId { get; set; }

		public DateTime? DataHoraAlteracao { get; set; }

		public bool Ativo { get; set; }

		public bool Excluido { get; set; }
	}
}
