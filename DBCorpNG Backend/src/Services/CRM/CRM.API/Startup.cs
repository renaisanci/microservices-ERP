

using System;
using System.Globalization;
using System.Text;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using MediatR;
using DBCorp.Common.Core.Model;
using DBCorp.Common.Core.Handler;
using DBCorp.Common.Core.Interface;
using DBCorp.Common.Core.Implementation;
using Microsoft.AspNetCore.Localization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CRM.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

            services.AddDbContext<DBCorp.CRM.Core.CRMDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionString"]));


 

            services.AddMvc()
            //coloquei para resolver letras maiuscula e minuscula no swap entre api e o angular
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
            services.AddOptions();
            services.AddAutoMapper();
            services.AddMediatR(typeof(Startup));
            services.Configure<DBCorp.Infrastructure.Services.Core.AppSettings>(Configuration.GetSection("Audience"));

            services.AddScoped<INotificationHandler<Notifications>, NotifiyHandler>();
            services.AddScoped<INotify, Notify>();

            services.AddScoped<DBCorp.Infrastructure.Services.Core.UnitOfWork.IUnitOfWork<DBCorp.CRM.Core.CRMDbContext>, DBCorp.Infrastructure.Services.Core.UnitOfWork.UnitOfWork<DBCorp.CRM.Core.CRMDbContext>>();
            services.AddScoped(typeof(DBCorp.Infrastructure.Services.Core.Repositories.IBaseRepository<,>), typeof(DBCorp.Infrastructure.Services.Core.Repositories.BaseRepository<,>));
            services.AddScoped<DBCorp.CRM.API.Services.Funil.IFunilService, DBCorp.CRM.API.Services.Funil.FunilService>();
            services.AddScoped<DBCorp.CRM.API.Services.Funil.IEtapaService, DBCorp.CRM.API.Services.Funil.EtapaService>();
            services.AddScoped<DBCorp.CRM.API.Services.Negocio.INegocioService, DBCorp.CRM.API.Services.Negocio.NegocioService>();
            //services.AddScoped<IMenuService, MenuService>();
            //services.AddScoped<IPerfilUsuarioService, PerfilUsuarioService>();


            var audienceConfig = Configuration.GetSection("Audience");

			var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = signingKey,
				ValidateIssuer = true,
				ValidIssuer = audienceConfig["Iss"],
				ValidateAudience = true,
				ValidAudience = audienceConfig["Aud"],
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				RequireExpirationTime = true,
			};

			services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = "IdentityApiKey";
			})
			.AddJwtBearer("IdentityApiKey", x =>
			{
				x.RequireHttpsMetadata = false;
				x.TokenValidationParameters = tokenValidationParameters;
			});


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
 
		}

		public void Configure(IApplicationBuilder app)
		{


            app.Use((context, next) =>
            {
                var userLangs = "pt-br";
                userLangs = context.Request.Headers["Language"].ToString();
                //switch culture
                Thread.CurrentThread.CurrentCulture = new CultureInfo(userLangs);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                //save for later use
                context.Items["ClientLang"] = userLangs;
                context.Items["ClientCulture"] = Thread.CurrentThread.CurrentUICulture.Name;


                // Call the next delegate/middleware in the pipeline
                return next();
            });



            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
			app.UseMvc();

     
        }
	}


    public class CustomerCultureProvider : RequestCultureProvider
    {
        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            //Go away and do a bunch of work to find out what culture we should do. 
            await Task.Yield();

            //Return a provider culture result. 
            return new ProviderCultureResult("pt-Br");

            //In the event I can't work out what culture I should use. Return null. 
            //Code will fall to other providers in the list OR use the default. 
            //return null;
        }
    }
}
