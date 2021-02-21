using System;
using System.Globalization;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace DBCorp.WebApp.ApiGateway
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; }
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder();

			builder.SetBasePath(env.ContentRootPath)
				   .AddJsonFile("appsettings.json")
				   .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
				   .AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();

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

			services.AddOcelot(Configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{

            // Definindo a cultura padrão: pt-BR
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });


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

            // global cors policy
            app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			app.UseAuthentication();
			app.UseOcelot().Wait();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
		}
	}
}
