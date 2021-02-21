using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DBCorp.ControleAcesso.API.Services.Menu;
using DBCorp.ControleAcesso.API.ViewModel;
using DBCorp.ControleAcesso.Core;
using DBCorp.Infrastructure.Services.Core.Repositories;
using DBCorp.Infrastructure.Services.Core.UnitOfWork;

namespace DBCorp.ControleAcesso.API.Services
{
	public class MenuService : IMenuService
	{
		private readonly IBaseRepository<Domain.Model.Menu, ControleAcessoDbContext> _menuRepo;
		private readonly IUnitOfWork<ControleAcessoDbContext> _unitOfWork;
		private IMapper _mapper;

		public MenuService(IUnitOfWork<ControleAcessoDbContext> unitOfWork, IBaseRepository<Domain.Model.Menu, ControleAcessoDbContext> menuRepo, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_menuRepo = menuRepo;
			_mapper = mapper;

		}

		public MontaMenu GetMenu()
		{
			var menu = _menuRepo.FindBy(m => m.Ativo);
			IEnumerable<MenuViewModel> menuVM = _mapper.Map<IEnumerable<DBCorp.ControleAcesso.Domain.Model.Menu>, IEnumerable<MenuViewModel>>(menu);
			var mn = new MontaMenu(menuVM.ToList());

			return mn;
		}
	}
}
