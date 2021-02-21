using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.Domain.Model
{
	public class MenuControle : BaseModel
	{
		public MenuControle() { }

		public int MenuId { get; set; }
		public virtual Menu Menu { get; set; }
		public string ElementName { get; set; }
		public string Descricao { get; set; }
	}
}
