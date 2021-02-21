using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DBCorp.ControleAcesso.Domain.Model;
using DBCorp.Infraestrutura.API.ViewModel;
using DBCorp.Infraestrutura.Core;
using DBCorp.Infrastructure.Domain.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBCorp.Infraestrutura.API.Controllers
{

	[Authorize(Roles = "Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class PessoaJuridicaController : Controller
	{
		private readonly InfraestruturaDbContext _context;
		private IMapper _mapper;

		public PessoaJuridicaController(InfraestruturaDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Pessoa
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoa()
		{
			return await _context.Pessoa.ToListAsync();
		}

		// GET: api/Pessoa/5
		[HttpGet("{id}")]
		public async Task<ActionResult<PessoaJuridica>> GetPessoaJuridica(int id)
		{
			var pessoaJuridica = await _context.PessoaJuridica.FindAsync(id);

			if (pessoaJuridica == null)
			{
				return NotFound();
			}

			return pessoaJuridica;
		}


		// GET: api/PessoaJuridica/nomeFantasia/cnpj/razaoSocial
		[HttpGet("{nomeFantasia}/{cnpj}/{razaoSocial}")]
		public async Task<IActionResult> GetPessoaJuridica(string nomeFantasia = null, string cnpj = null, string razaoSocial = null)
		{
			var pj = new List<PessoaJuridica>();


			if (nomeFantasia == "null" && cnpj == "null" && razaoSocial == "null")
			{
				pj = await _context.PessoaJuridica.Where(x => x.Excluido == false).Take(100).ToListAsync();
			}
			else
			{

				pj = await _context.PessoaJuridica.Where(x => x.NomeFantasia.Contains(nomeFantasia) || x.Cnpj.Contains(cnpj) || x.RazaoSocial.Contains(razaoSocial) && x.Excluido == false).ToListAsync();
			}
			if (pj == null)
			{
				return NotFound();
			}

			var pessoaJuridicaVM = _mapper.Map<IEnumerable<PessoaJuridica>, IEnumerable<PessoaJuridicaViewModel>>(pj);
			return Json(pessoaJuridicaVM);
		}


		// PUT: api/Pessoa/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPessoa(int Id, PessoaJuridica pessoa)
		{

			var idPessoa = _context.PessoaJuridica.Where(e => e.Id == Id).Select(x => x.PessoaId).ToList().FirstOrDefault();
			pessoa.PessoaId = idPessoa;
			if (Id != pessoa.Id)
			{
				return BadRequest();
			}

			_context.Entry(pessoa).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PessoaExists(Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}


		// POST: api/Pessoa
		[HttpPost]
		public async Task<ActionResult<PessoaJuridica>> PostPessoa(PessoaJuridica pessoaJuridica)
		{

			Pessoa pessoa = new Pessoa()
			{
				TipoPessoa = TipoPessoa.PessoaJuridica

			};

			_context.Pessoa.Add(pessoa);
			_context.SaveChanges();

			pessoaJuridica.PessoaId = pessoa.Id;



			_context.PessoaJuridica.Add(pessoaJuridica);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPessoaJuridica", new { id = pessoaJuridica.Id }, pessoaJuridica);
		}


		// DELETE: api/Pessoa/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<PessoaJuridica>> DeletePessoa(int id)
		{
			var pessoa = await _context.PessoaJuridica.FindAsync(id);
			if (pessoa == null)
			{
				return NotFound();
			}

			_context.PessoaJuridica.Remove(pessoa);
			await _context.SaveChangesAsync();

			return pessoa;
		}

		private bool PessoaExists(int id)
		{
			return _context.PessoaJuridica.Any(e => e.Id == id);
		}
	}
}
