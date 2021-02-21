using System;
using System.Collections.Generic;
using System.Linq;
using DBCorp.ControleAcesso.Core;
using DBCorp.Infrastructure.Services.Core;
using DBCorp.Infrastructure.Domain.Core.Model;
using Microsoft.Extensions.Options;

namespace DBCorp.ControleAcesso.API.Services
{
	public class UserService : IUserService
	{
		private ControleAcessoDbContext _context;
		private readonly AppSettings _appSettings;

		public UserService(ControleAcessoDbContext context, IOptions<AppSettings> appSettings)
		{
			_context = context;
			_appSettings = appSettings.Value;
		}

		public Usuario Authenticate(string username, string password)
		{
			var user = _context.Usuario.SingleOrDefault(x => x.Username == username);
			// check if password is correct
			if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
				return null;

			return user;
		}

		private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
		{
			if (password == null) throw new ArgumentNullException("password");
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
			if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
			if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

			using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != storedHash[i]) return false;
				}
			}

			return true;
		}

		public IEnumerable<Usuario> GetAll()
		{
			return _context.Usuario;
		}

		public Usuario GetById(int id)
		{
			var user = _context.Usuario.FirstOrDefault(x => x.Id == id);

			// return user without password
			//if (user != null)
			//  user.Password = null;

			return user;
		}

		public Usuario Create(Usuario user, string password)
		{
			// validation
			if (string.IsNullOrWhiteSpace(password))
				throw new AppException("Usuário obrigatório.");

			if (_context.Usuario.Any(x => x.Username == user.Username))
				throw new AppException("Usuário \"" + user.Username + "\" já existe.");

			Pessoa pessoa = new Pessoa()
			{
				TipoPessoa = TipoPessoa.PessoaRobo,

			};

			//_context.Pessoa.Add(pessoa);
			_context.SaveChanges();

			byte[] passwordHash, passwordSalt;
			CreatePasswordHash(password, out passwordHash, out passwordSalt);

			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;
			user.PessoaId = pessoa.Id;

			_context.Usuario.Add(user);
			_context.SaveChanges();

			return user;
		}

		private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			if (password == null) throw new ArgumentNullException("password");
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		public void Update(Usuario userParam, string password = null)
		{
			var user = _context.Usuario.Find(userParam.Id);

			if (user == null)
				throw new AppException("User not found");

			if (userParam.Username != user.Username)
			{
				// username has changed so check if the new username is already taken
				if (_context.Usuario.Any(x => x.Username == userParam.Username))
					throw new AppException("Username " + userParam.Username + " is already taken");
			}

			// update user properties
			user.PrimeiroNome = userParam.PrimeiroNome;
			user.UltimoNome = userParam.UltimoNome;
			user.Username = userParam.Username;

			// update password if it was entered
			if (!string.IsNullOrWhiteSpace(password))
			{
				byte[] passwordHash, passwordSalt;
				CreatePasswordHash(password, out passwordHash, out passwordSalt);

				user.PasswordHash = passwordHash;
				user.PasswordSalt = passwordSalt;
			}

			_context.Usuario.Update(user);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var user = _context.Usuario.Find(id);
			if (user != null)
			{
				_context.Usuario.Remove(user);
				_context.SaveChanges();
			}
		}
	}
}