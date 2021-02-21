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
	public class PessoaFisicaController : Controller
	{
		private readonly InfraestruturaDbContext _context;

		private IMapper _mapper;

		public PessoaFisicaController(InfraestruturaDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/PessoaFisica/nome/sobrenome/cpf
		[HttpGet("{nome?}/{sobrenome?}/{cpf?}")]
		public async Task<IActionResult> GetPessoaFisica(string nome = null, string sobrenome = null, string cpf = null)
		{

			var pf = new List<PessoaFisica>();

			if (nome == "null" && sobrenome == "null" && cpf == "null")
			{
				pf = await _context.PessoaFisica.Where(x => x.Excluido == false).Take(100).ToListAsync();
			}
			else
			{

				pf = await _context.PessoaFisica.Where(x => x.Nome.Contains(nome) || x.Sobrenome.Contains(sobrenome) || x.Cpf.Contains(cpf) && x.Excluido == false).ToListAsync();
			}
			if (pf == null)
			{
				return NotFound();
			}

			var pessoaFisicaVM = _mapper.Map<IEnumerable<PessoaFisica>, IEnumerable<PessoaFisicaViewModel>>(pf);
			return Json(pessoaFisicaVM);
		}


		// GET: api/Pessoa/5
		[HttpGet("{id}")]
		public async Task<ActionResult<PessoaFisica>> GetPessoaFisica(int id)
		{
			var pessoaFisica = await _context.PessoaFisica.FindAsync(id);

			if (pessoaFisica == null)
			{
				return NotFound();
			}

			return pessoaFisica;
		}


		// PUT: api/Pessoa/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPessoa(int Id, PessoaFisica pessoa)
		{

			var idPessoa = _context.PessoaFisica.Where(e => e.Id == Id).Select(x => x.PessoaId).ToList().FirstOrDefault();

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
		public async Task<ActionResult<PessoaFisica>> PostPessoa(PessoaFisica pessoaFisica)
		{
			Pessoa pessoa = new Pessoa()
			{
				TipoPessoa = TipoPessoa.PessoaFisica

			};

			_context.Pessoa.Add(pessoa);
			_context.SaveChanges();

			pessoaFisica.PessoaId = pessoa.Id;

			_context.PessoaFisica.Add(pessoaFisica);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPessoaFisica", new { id = pessoaFisica.Id }, pessoaFisica);
		}

		// DELETE: api/Pessoa/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<PessoaFisica>> DeletePessoa(int Id)
		{
			var pessoa = await _context.PessoaFisica.FindAsync(Id);

			pessoa.Excluido = true;
			if (pessoa == null)
			{
				return NotFound();
			}

			_context.Entry(pessoa).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return pessoa;
		}

		private bool PessoaExists(int id)
		{
			return _context.PessoaFisica.Any(e => e.Id == id);
		}
	}
}
