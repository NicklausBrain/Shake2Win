using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Shake2Win.Web.Data;

namespace Shake2Win.Web
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddMvc(options => options.EnableEndpointRouting = false)
				.AddNewtonsoftJson();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sake2Win API", Version = "v1" });
			});

			services.AddSingleton<IdGenerator>();
			services.AddSingleton<PlayroomsRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseHsts();

			app.UseHttpsRedirection();

			app.UseDeveloperExceptionPage();

			app.UseDefaultFiles();

			app.UseStaticFiles();

			app.UseMvcWithDefaultRoute();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sake2Win API V1");
			});
		}
	}
}
