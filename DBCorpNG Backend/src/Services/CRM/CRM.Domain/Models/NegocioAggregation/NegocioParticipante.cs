using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.CRM.Domain.Models.NegocioAggregation
{
	public class NegocioParticipante : BaseModel
	{
		public Negocio Negocio { get; set; }
		public int NegocioId { get; set; }

		public Participante Participante { get; set; }
		public int ParticipanteId { get; set; }
	}
}
