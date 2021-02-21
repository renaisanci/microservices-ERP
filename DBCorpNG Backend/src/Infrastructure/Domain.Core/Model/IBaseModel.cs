using System;

namespace DBCorp.Infrastructure.Domain.Core.Model
{
	public interface IBaseModel
	{
		int Id { get; set; }

		Usuario UsuarioCriacao { get; set; }
		int? UsuarioCriacaoId { get; set; }

		DateTime DataHoraCriacao { get; set; }

		Usuario UsuarioAlteracao { get; set; }
		int? UsuarioAlteracaoId { get; set; }

		DateTime? DataHoraAlteracao { get; set; }

		bool Ativo { get; set; }

		bool Excluido { get; set; }
	}
}
