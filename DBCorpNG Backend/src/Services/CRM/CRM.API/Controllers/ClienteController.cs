using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace CRM.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : Controller
	{
		// GET: api/<controller>
		[AllowAnonymous]
		[HttpGet]
		public IEnumerable<string> Get()
		{
			//pega o usuário logado 
			//var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

			return new string[] { "Cliente CRM value1", "Cliente CRM  value2" };
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "Cliente CRM  value";
		}

		// POST api/<controller>
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
