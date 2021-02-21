using System;
using System.Collections.Generic;
using System.Linq;
using DBCorp.Infrastructure.Services.Core.Repositories;
using DBCorp.Infrastructure.Services.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using DBCorp.CRM.Domain.Models.FunilAggregation;

namespace DBCorp.CRM.API.Services.Funil
{
    public class FunilService : IFunilService
    {

        private readonly Infrastructure.Services.Core.AppSettings _appSettings;
        private readonly IBaseRepository<Domain.Models.FunilAggregation.Funil, Core.CRMDbContext> _funilRep;
        private readonly IBaseRepository<Domain.Models.FunilAggregation.FunilEtapa, Core.CRMDbContext> _funilEtapaRep;

        protected readonly IUnitOfWork<Core.CRMDbContext> _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public FunilService(IHttpContextAccessor httpContextAccessor, IBaseRepository<Domain.Models.FunilAggregation.Funil, Core.CRMDbContext> funilRep, IBaseRepository<Domain.Models.FunilAggregation.FunilEtapa, Core.CRMDbContext> funilEtapaRep, Microsoft.Extensions.Options.IOptions<Infrastructure.Services.Core.AppSettings> appSettings, IUnitOfWork<Core.CRMDbContext> unitOfWork)
        {
            _funilRep = funilRep;
            _funilEtapaRep = funilEtapaRep;
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }


        public Domain.Models.FunilAggregation.Funil Create(Domain.Models.FunilAggregation.Funil funil)
        {
            verificaFunilDefault(funil);

            if (_funilRep.FindBy(x => x.Titulo == funil.Titulo && x.Excluido==false).Any())  
                throw new Infrastructure.Services.Core.AppException("Funil \"" + funil.Titulo + "\" já existe.");
          
            funil.UsuarioCriacaoId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            for (int i = 0; i < funil.Etapas.Count; i++){funil.Etapas[i].UsuarioCriacaoId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));}
            _funilRep.Add(funil);
            _unitOfWork.Commit();
            return funil;
        }

        public void Delete(int id)
        {
            var funil = _funilRep.GetSingle(id);
            funil.Excluido = true;
            _funilRep.Edit(funil);
            _unitOfWork.Commit();
        }

        public IEnumerable<Domain.Models.FunilAggregation.Funil> GetFunil(string titulo)
        {
            return _funilRep.FindBy(x => EF.Functions.Like(x.Titulo, "%" + titulo + "%") && x.Excluido == false).Include(x => x.Etapas);
        }


        public IEnumerable<Domain.Models.FunilAggregation.Funil> GetAll()
        {
            return _funilRep.FindBy(x=>x.Excluido==false).Include(x => x.Etapas);
        }

        public Domain.Models.FunilAggregation.Funil GetById(int id)
        {
            return _funilRep.GetSingle(id);

        }

        public void Update(Domain.Models.FunilAggregation.Funil funil)
        {
            verificaFunilDefault(funil);
            for (int i = 0; i < funil.Etapas.Count; i++)
            { funil.Etapas[i].UsuarioAlteracaoId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); }
            _funilRep.Edit(funil);
            _unitOfWork.Commit();

        }



        public void verificaFunilDefault(Domain.Models.FunilAggregation.Funil funil)
        {
            // se o funil que esta sendo criado é o padrão ou seja o default, vericamos se existe algum no banco como default e colocamos como false
            if (funil.Default)
            {
                var funilDefault = _funilRep.FindBy(x => x.Default).FirstOrDefault();
                if (funilDefault != null)
                {
                    funilDefault.Default = false;
                    _funilRep.Edit(funilDefault);
                    _unitOfWork.Commit();
                }
            }
        }

    }
}
