using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DBCorp.ControleAcesso.API.Services;
using DBCorp.ControleAcesso.API.Services.PerfilUsuario;
using DBCorp.ControleAcesso.API.ViewModel;
using DBCorp.Infrastructure.Domain.Core.Model;
using DBCorp.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthServer.Controllers
{


	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private readonly AppSettings _appSettings;
		private IUserService _userService;
		private IPerfilUsuarioService _perfilUsuarioService;
		private IMapper _mapper;

		public AuthController(IOptions<AppSettings> appSettings, IUserService userService, IPerfilUsuarioService perfilUsuarioService, IMapper mapper)
		{
			_appSettings = appSettings.Value;
			_userService = userService;
			_perfilUsuarioService = perfilUsuarioService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var users = _userService.GetAll();
			var usuarioVM = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(users);

			return Json(usuarioVM);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_userService.Delete(id);
			return Ok();
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody]UsuarioViewModel userParam)
		{
			var user = _userService.Authenticate(userParam.Username, userParam.Password);

			if (user == null)
				return BadRequest(new { message = "Usuário ou Senha incorreto." });

			var now = DateTime.UtcNow;
			//Pega todos os perfis no qual o usuário esta atrelado
			string[] perfil = _perfilUsuarioService.GetPerfilUsuario(user.Id).Select(x => x.DescPerfil).ToArray();

			var claims = new List<Claim>();

			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
			claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Username));
			claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
			claims.Add(new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64));
			
			//Add todos o perfis no usuário no autorize
			foreach (var itemPerfil in perfil)
			{
				claims.Add(new Claim(ClaimTypes.Role, itemPerfil));
			}

			var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = signingKey,
				ValidateIssuer = true,
				ValidIssuer = _appSettings.Iss,
				ValidateAudience = true,
				ValidAudience = _appSettings.Aud,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				RequireExpirationTime = true,
			};

			var jwt = new JwtSecurityToken(
				issuer: _appSettings.Iss,
				audience: _appSettings.Aud,
				claims: claims,
				notBefore: now,
				expires: DateTime.Now.AddDays(30),
				signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
			);
			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
			var responseJson = new
			{
				access_token = encodedJwt,
				expires_in = (int)TimeSpan.FromMinutes(2).TotalSeconds
			};
			user.Token = responseJson.access_token;
			user.PasswordHash = null;
			user.PasswordSalt = null;
			UsuarioViewModel User = _mapper.Map<Usuario, UsuarioViewModel>(user);

			return Ok(User);
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public IActionResult Register([FromBody]UsuarioViewModel usuarioViewModel)
		{
			var user = _mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);

			try
			{
				// save 
				_userService.Create(user, usuarioViewModel.Password);

				return Ok();
			}
			catch (AppException ex)
			{
				// return error message if there was an exception
				return BadRequest(new { message = ex.Message });
			}
		}
	}
}
