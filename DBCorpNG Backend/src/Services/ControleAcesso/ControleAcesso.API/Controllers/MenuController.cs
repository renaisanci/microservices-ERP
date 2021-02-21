using System.Linq;
using AutoMapper;
using DBCorp.ControleAcesso.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBCorp.ControleAcesso.API.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class MenuController : Controller
	{
		private IMenuService _menuService;
		private IMapper _mapper;

		public MenuController(IMenuService menuService, IMapper mapper)
		{
			_menuService = menuService;
			_mapper = mapper;
		}

		// GET: api/<controller>
		[Authorize]
		[HttpGet]
		public IActionResult Get()
		{
			var menu = _menuService.GetMenu();
			return Json(menu.OrderBy(x => x.Ordem).OrderBy(x => x.DescMenu));
		}
	}
}