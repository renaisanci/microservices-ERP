
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
    public class FunilController : Controller
    {

     
        private IMapper _mapper;
        private IFunilService _funilService;
        private IEtapaService _etapaService;


        public FunilController(IEtapaService etapaService, IFunilService funilService, IMapper mapper)
        {
            _funilService = funilService;
            _mapper = mapper;
            _etapaService = etapaService;
        }



        // GET: api/Funil/{titulo}

        [HttpGet("GetFunil/{titulo?}")]
        public IActionResult GetFunil(string titulo=null)
        {
            try
            {
                IEnumerable<Funil> funil = null;

                if (titulo == "null") {
                     funil = _funilService.GetAll();
                }
                else
                {
                     funil = _funilService.GetFunil(titulo);
                }


                var funisVmM = _mapper.Map<IEnumerable<Funil>, IEnumerable<FunilViewModel>>(funil);

                return Json(funisVmM);

            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }



        // GET: api/Funil
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

               var  funil = _funilService.GetAll();
                var funisVmM = _mapper.Map<IEnumerable<Funil>, IEnumerable<FunilViewModel>>(funil);

                return Json(funisVmM);

            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Funil/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Funil
        [HttpPost]
        public IActionResult Post(FunilViewModel funilViewModel)
        {

            var funil = _mapper.Map<FunilViewModel, Funil>(funilViewModel);
            try
            {
                 _funilService.Create(funil);             
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

 


        // PUT: api/Funil/5
        [HttpPut("{Id}")]
        public IActionResult Put(FunilViewModel funilViewModel, int Id)
        {
            for (int i = 0; i < funilViewModel.Etapas.Count; i++)
            {              
                if (funilViewModel.Etapas[i].Id == 0 && funilViewModel.Etapas[i].FunilId == 0)
                {
                    var funilEtapa = new FunilEtapa()
                    {
                        FunilId = funilViewModel.Id,
                        Nome = funilViewModel.Etapas[i].Nome,
                        Ordem = short.Parse(funilViewModel.Etapas[i].Ordem.ToString())
                    };
                    _etapaService.Create(funilEtapa);
                    funilViewModel.Etapas[i].Id = funilEtapa.Id;
                    funilViewModel.Etapas[i].FunilId = funilViewModel.Id;
                }
                else
                {
                    var etapa = _mapper.Map<EtapaViewModel, FunilEtapa>(funilViewModel.Etapas[i]);
                    _etapaService.Update(etapa);
                }

            }
            var funil = _mapper.Map<FunilViewModel, Funil>(funilViewModel);
            try
            {
                _funilService.Update(funil);
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
            _funilService.Delete(id);

        }
    }
}
