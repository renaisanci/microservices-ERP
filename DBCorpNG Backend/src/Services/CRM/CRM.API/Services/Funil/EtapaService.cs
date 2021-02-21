using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBCorp.CRM.Domain.Models.FunilAggregation;
using DBCorp.Infrastructure.Services.Core.Repositories;
using DBCorp.Infrastructure.Services.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DBCorp.CRM.API.Services.Funil
{
    public class EtapaService : IEtapaService
    {




        private readonly Infrastructure.Services.Core.AppSettings _appSettings;
        private readonly IBaseRepository<FunilEtapa, Core.CRMDbContext> _funilEtapaRep;
        protected readonly IUnitOfWork<Core.CRMDbContext> _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public EtapaService(IHttpContextAccessor httpContextAccessor,   IBaseRepository<FunilEtapa, Core.CRMDbContext> funilEtapaRep, Microsoft.Extensions.Options.IOptions<Infrastructure.Services.Core.AppSettings> appSettings, IUnitOfWork<Core.CRMDbContext> unitOfWork)
        {
          
            _funilEtapaRep = funilEtapaRep;
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

 

        IEnumerable<FunilEtapa> IEtapaService.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<FunilEtapa> IEtapaService.GetByFunilId(int id)
        {

            if(id==0)
                return _funilEtapaRep.FindBy(x => x.Funil.Default &&  x.Ativo && x.Excluido == false).OrderBy(x => x.Ordem).Include(x => x.Negocios);


            return _funilEtapaRep.FindBy(x => x.FunilId == id && x.Ativo && x.Excluido==false).OrderBy(x=>x.Ordem).Include(x => x.Negocios);
        }

        FunilEtapa IEtapaService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        FunilEtapa IEtapaService.Create(FunilEtapa etapa)
        {
            //if (_funilEtapaRep.FindBy(x => x.Nome == etapa.Nome).Any())
            //{
            //    throw new Infrastructure.Services.Core.AppException("Nome \"" + etapa.Nome + "\" já existe.");
            //}
            etapa.UsuarioCriacaoId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            _funilEtapaRep.Add(etapa);
            _unitOfWork.Commit();
            return etapa;
        }

        void IEtapaService.Update(FunilEtapa etapa)
        {
            etapa.UsuarioAlteracaoId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            _funilEtapaRep.Edit(etapa);
            _unitOfWork.Commit();
        }

        void IEtapaService.Delete(int id)
        {
           var etapa = _funilEtapaRep.GetSingle(id);
            _funilEtapaRep.Delete(etapa);
            _unitOfWork.Commit();
       
        }
    }
}
