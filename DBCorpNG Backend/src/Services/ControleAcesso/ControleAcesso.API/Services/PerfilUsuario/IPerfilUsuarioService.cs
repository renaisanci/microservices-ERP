using DBCorp.ControleAcesso.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCorp.ControleAcesso.API.Services.PerfilUsuario
{
   public  interface IPerfilUsuarioService
    {

        List<PerfilUsuarioViewModel> GetPerfilUsuario(int UsuarioId);
    }
}
