using APIVersioning.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APIVersioning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddMvcCore();
            services.AddApiVersioning(o =>
            {
                #region CombineVersionReader
                o.ApiVersionReader = ApiVersionReader.Combine(
                    //https://localhost:44358/api/student?api-version=3
                    new QueryStringApiVersionReader(),
                    //https://localhost:44358/api/student?v=3
                    new QueryStringApiVersionReader("v")

                    //new HeaderApiVersionReader("api-version"),
                    //// Content-Type: application/json;v=2.0
                    //new MediaTypeApiVersionReader(),
                    //// Content-Type: application/json;version=2.0
                    //new MediaTypeApiVersionReader("version")
                    );
                #endregion

                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(3, 0);

                #region VersionSupportedController
                o.Conventions.Controller<StudentController>().HasApiVersion(new ApiVersion(3,1));

                #endregion
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseApiVersioning();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
