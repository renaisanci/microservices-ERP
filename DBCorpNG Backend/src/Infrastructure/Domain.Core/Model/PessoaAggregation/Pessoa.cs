using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCorp.Infrastructure.Domain.Core.Model
{
	[Table("Pessoa", Schema = "Infraestrutura")]
	public class Pessoa : BaseModel, IAggregationRoot
	{
		public Pessoa()
		{
			// Usuarios = new List<Usuario>();
		}

		public TipoPessoa TipoPessoa { get; set; }


        //public virtual Usuario Usuario { get; set; }
        //public  int? UsuarioId { get; set; }

         public virtual ICollection<Usuario> Usuarios { get; set; }



    }
}
