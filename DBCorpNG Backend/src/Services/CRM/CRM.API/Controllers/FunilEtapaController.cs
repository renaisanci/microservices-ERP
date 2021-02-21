using System.Collections.Generic;
using AutoMapper;
using DBCorp.CRM.API.Services.Funil;
using DBCorp.CRM.API.ViewModel;
using DBCorp.CRM.Domain.Models.FunilAggregation;
using DBCorp.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
 
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FunilEtapaController : Controller
    {

        private IMapper _mapper;
        private IEtapaService _etapaService;


        public FunilEtapaController(IEtapaService etapaService, IMapper mapper)
        {
            _etapaService = etapaService;
            _mapper = mapper;
        }




        // GET: api/FunilEtapa
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/FunilEtapa/5
        [HttpGet("GetFunilEtapa/{Id}")]
        public IActionResult GetFunilEtapa(int Id)
        {
            try
            {



                var etapasNegocio = _etapaService.GetByFunilId(Id);
                var etapasNegocioVM = _mapper.Map<IEnumerable<FunilEtapa>, IEnumerable<EtapaViewModel>>(etapasNegocio);
                return Json(etapasNegocioVM);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        

        // POST: api/FunilEtapa
        [HttpPost]
        public void Post([FromBody] string value)
        {




        }

        // PUT: api/FunilEtapa/5
        [HttpPut("{Id}")]
        public IActionResult Put(EtapaViewModel etapaViewModel, int Id)
        {
            var etapa = _mapper.Map<EtapaViewModel, FunilEtapa>(etapaViewModel);
            try
            {
                _etapaService.Update(etapa);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _etapaService.Delete(id);
        }
    }
}
