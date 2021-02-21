using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DBCorp.CRM.API.Services.Negocio;
using DBCorp.CRM.API.ViewModel;
using DBCorp.CRM.Domain.Models.NegocioAggregation;
using DBCorp.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{


    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : Controller
    {



        private IMapper _mapper;
        private INegocioService _negocioService;
 


        public NegocioController(INegocioService negocioService, IMapper mapper)
        {
            _negocioService = negocioService;
            _mapper = mapper;
         
        }





        // GET: api/Negocio
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Negocio/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Negocio
        [HttpPost]
        public IActionResult Post(NegocioViewModel negocioViewModel)
        {

            negocioViewModel.RepresentanteId = 3;
            var negocio = _mapper.Map<NegocioViewModel, Negocio>(negocioViewModel);
            try
            {
                _negocioService.Create(negocio);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Negocio/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
