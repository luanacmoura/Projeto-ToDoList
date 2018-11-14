using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Projeto_ToDoList
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(
                options => options.IdleTimeout=TimeSpan.FromMinutes(10) //Definindo que após 10 minutos, ele desloga(tempo limite)
            );
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Para poder usar funções referentes a sessão de usuário
            app.UseSession();

            //Para poder interpretar arquivos estáticos (css por ex.)
            app.UseStaticFiles();
            
            //Definindo rota default da aplicação
            app.UseMvc(
                root => root.MapRoute(
                    name:"default",
                    template:"{controller=Usuario}/{action=Login}"
                )
            );

            

            
        }
    }
}
