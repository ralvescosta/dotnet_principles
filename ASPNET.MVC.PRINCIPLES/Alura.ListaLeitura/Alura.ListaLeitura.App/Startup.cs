using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    internal class Startup
    {
        public void Configure(IApplicationBuilder app) 
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}