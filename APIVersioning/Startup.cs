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
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);

                #region HeaderApiVersionReader
                //o.ApiVersionReader = new HeaderApiVersionReader("api-version");

                #endregion

                #region QueryStringApiVersionReader
                // svc?api-version=2.0
                //o.ApiVersionReader = new QueryStringApiVersionReader();

                // svc?v=2.0
                //o.ApiVersionReader = new QueryStringApiVersionReader("v");
                #endregion

                #region CombineVersionReader
                //o.ApiVersionReader = ApiVersionReader.Combine(
                //    new QueryStringApiVersionReader(),
                //    new HeaderApiVersionReader()
                //    {
                //        Headers = { "api-version" }
                //    });
                #endregion

                #region VersionSupportedController
                o.Conventions.Controller<StudentController>().HasApiVersion(new ApiVersion(3, 1));

                #endregion
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
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
