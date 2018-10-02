using Fiap01.Data;
using Fiap01.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = 
    @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<PerguntasContext>(o => o.UseSqlServer(connection));

            services.AddMvc();
        }
        public void Configure( IApplicationBuilder app, IHostingEnvironment env)
        {


            #region Commentado
            //app.Use((context, next) =>
            //{
            //    context.Response.Headers.Add("X-teste", "headerteste");
            //    return next();
            //});
            //app.Use(async (context, next) =>
            //{
            //    var teste = 123;
            //    await next.Invoke();
            //    var teste2 = 1234;
            //    //await context.Response.WriteAsync("teste"); // <-- Más Práticas
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("boa noite");
            //});
            #endregion

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            //app.UseMiddleware<LogMiddleware>(); 
            app.UseMeuLogoPreza();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller}/{action}/{id?}"
                   );

                #region Aula 01 - 
                //routes.MapRoute(
                //    name: "autor",
                //    template: "autor/{nome}",
                //    defaults: new { controller = "Autor", action = "Index" }
                //    );

                //routes.MapRoute(
                //  name: "autoresDoAno",
                //  template: "{ano:int}/autor",
                //  defaults: new { controller = "Autor", action = "ListarAutoresDoAno" }
                //  );

                //routes.MapRoute(
                //  name: "topicodacategoria",
                //  template: "{categoria}/{topico}",
                //  defaults: new { controller = "Topico", action = "Index" }
                //  );
                #endregion
            });            
        }
    }

}
