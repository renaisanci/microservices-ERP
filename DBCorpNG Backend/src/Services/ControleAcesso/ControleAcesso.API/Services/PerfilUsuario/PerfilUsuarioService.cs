using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DBCorp.ControleAcesso.API.ViewModel;
using DBCorp.ControleAcesso.Core;
using DBCorp.Infrastructure.Services.Core.Repositories;
using DBCorp.Infrastructure.Services.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DBCorp.ControleAcesso.API.Services.PerfilUsuario
{
	public class PerfilUsuarioService : IPerfilUsuarioService
	{
		#region Injeção de dependencias 

		private readonly IBaseRepository<Domain.Model.PerfilUsuario, ControleAcessoDbContext> _perfilUsuarioRepo;
		private readonly IUnitOfWork<ControleAcessoDbContext> _unitOfWork;
		private IMapper _mapper;

		#endregion

		#region Construtor

		public PerfilUsuarioService(IUnitOfWork<ControleAcessoDbContext> unitOfWork, IBaseRepository<Domain.Model.PerfilUsuario, ControleAcessoDbContext> perfilUsuarioRepo, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_perfilUsuarioRepo = perfilUsuarioRepo;
			_mapper = mapper;

		}

		#endregion

		public List<PerfilUsuarioViewModel> GetPerfilUsuario(int UsuarioId)
		{
			var perfilUsuario = _perfilUsuarioRepo
				.FindBy(x => x.UsuarioId == UsuarioId)
				.Include(p => p.Perfil);

			//var perfilUsuario = _perfilUsuarioRepo.GetAll().Where(x => x.UsuarioId == UsuarioId);
			List<PerfilUsuarioViewModel> perfilUsuarioVM = _mapper.Map<IEnumerable<DBCorp.ControleAcesso.Domain.Model.PerfilUsuario>, IEnumerable<PerfilUsuarioViewModel>>(perfilUsuario).ToList();

			return perfilUsuarioVM;
		}
	}
}