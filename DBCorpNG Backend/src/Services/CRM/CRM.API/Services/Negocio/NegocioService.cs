using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DBCorp.CRM.Domain.Models.NegocioAggregation;
using DBCorp.Infrastructure.Services.Core.Repositories;
using DBCorp.Infrastructure.Services.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DBCorp.CRM.API.Services.Negocio
{
    public class NegocioService : INegocioService
    {



        private readonly Infrastructure.Services.Core.AppSettings _appSettings;
        private readonly IBaseRepository<Domain.Models.NegocioAggregation.Negocio, Core.CRMDbContext> _negocioRep;
        protected readonly IUnitOfWork<Core.CRMDbContext> _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public NegocioService(IHttpContextAccessor httpContextAccessor, IBaseRepository<Domain.Models.NegocioAggregation.Negocio, Core.CRMDbContext> negocioRep, Microsoft.Extensions.Options.IOptions<Infrastructure.Services.Core.AppSettings> appSettings, IUnitOfWork<Core.CRMDbContext> unitOfWork)
        {

            _negocioRep = negocioRep;
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }


        //Domain.Models.NegocioAggregation.Negocio Create(Domain.Models.NegocioAggregation.Negocio negocio)
        //{
        //    if (_negocioRep.FindBy(x => x.Titulo == negocio.Titulo).Any())
        //    {
        //        throw new Infrastructure.Services.Core.AppException("Nome \"" + negocio.Titulo + "\" já existe.");
        //    }
        //    negocio.UsuarioCriacaoId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    _negocioRep.Add(negocio);
        //    _unitOfWork.Commit();
        //    return negocio;
        //}

        public IEnumerable<Domain.Models.NegocioAggregation.Negocio> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.NegocioAggregation.Negocio> GetFunil(string titulo)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.NegocioAggregation.Negocio GetById(int id)
        {
            throw new NotImplementedException();
        }

     

        public void Update(Domain.Models.NegocioAggregation.Negocio funil)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        Domain.Models.NegocioAggregation.Negocio INegocioService.Create(Domain.Models.NegocioAggregation.Negocio negocio)
        {
            if (_negocioRep.FindBy(x => x.Titulo == negocio.Titulo && x.FunilEtapaId==negocio.FunilEtapaId ).Any())
            {
                throw new Infrastructure.Services.Core.AppException("Nome \"" + negocio.Titulo + "\" já existe.");
            }
            negocio.UsuarioCriacaoId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            _negocioRep.Add(negocio);
            _unitOfWork.Commit();
            return negocio;
        }
    }
}
