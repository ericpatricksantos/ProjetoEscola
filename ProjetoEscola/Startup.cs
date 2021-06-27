using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoEscola.Repositories.Implementations;
using ProjetoEscola.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola
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
            services.AddControllersWithViews();

            //registra o meu repositorio como servico
            services.AddTransient<IAlunoRepository,AlunoRepository>();

            //registra o meu repositorio como servico
            services.AddTransient<ICursoRepository, CursoRepository>();

            //registra o meu repositorio como servico
            services.AddTransient<IDisciplinaRepository, DisciplinaRepository>();

            //registra o meu repositorio como servico
            services.AddTransient<IMatriculaRepository, MatriculaRepository>();

            //registra o meu repositorio como servico
            services.AddTransient<IAluno_DisciplinaRepository, Aluno_DisciplinaRepository>();

            //registra o meu repositorio como servico
            services.AddTransient<ICurso_DisciplinaRepository, Curso_DisciplinaRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
