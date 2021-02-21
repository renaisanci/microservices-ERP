using System;
using System.Globalization;
using System.Text;
using System.Threading;
using AutoMapper;
using DBCorp.ControleAcesso.API.Services;
using DBCorp.ControleAcesso.API.Services.PerfilUsuario;
using DBCorp.ControleAcesso.Core;
using DBCorp.Infrastructure.Services.Core;
using DBCorp.Infrastructure.Services.Core.Repositories;
using DBCorp.Infrastructure.Services.Core.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace DBCorp.ControleAcesso.API
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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddDbContext<ControleAcessoDbContext>(options =>
				options.UseSqlServer(Configuration["ConnectionString"]));

			services.AddMvc()
					//coloquei para resolver letras maiuscula e minuscula no swap entre api e o angular
					.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

			services.AddOptions();
			services.AddAutoMapper();
			services.Configure<AppSettings>(Configuration.GetSection("Audience"));
			services.AddScoped<IUnitOfWork<ControleAcessoDbContext>, UnitOfWork<ControleAcessoDbContext>>();
			services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IMenuService, MenuService>();
			services.AddScoped<IPerfilUsuarioService, PerfilUsuarioService>();

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

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1",
					new Info
					{
						Title = "DBCorp NG - Controle de acesso HTTP API",
						Version = "v1",
						Description = "Microservice HTTP API. Modulo Controle de acesso",
					});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{

			app.Use((context, next) =>
			{
				var userLangs = "pt";
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

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.RoutePrefix = "swagger";
				c.SwaggerEndpoint("../swagger/v1/swagger.json", "CA.API v1");
			});

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseMvc();

			// Criar os registro default declarados no OnModelCreating
			//context.Database.EnsureCreated();
		}
	}
}
