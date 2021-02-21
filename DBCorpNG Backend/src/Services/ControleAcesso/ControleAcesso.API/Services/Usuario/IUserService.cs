using System.Collections.Generic;
using DBCorp.Infrastructure.Domain.Core.Model;

namespace DBCorp.ControleAcesso.API.Services
{
	public interface IUserService
    {
        Usuario Authenticate(string username, string password);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        Usuario Create(Usuario user, string password);
        void Update(Usuario user, string password = null);
        void Delete(int id);
    }
}
