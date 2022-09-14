using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PetLove.API
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

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "PetLove.API", 
                    Version = "v1", 
                    Description = "API para o ramo da saúde, que inicialmente focará em consultas agendadas, com diferentes médicos veterinários disponíveis na clínica em determinados dias e horários da semana.",
                    TermsOfService = new Uri("https://github.com/rfagner"),
                    Contact = new OpenApiContact
                    {
                        Name = "Renildo Fagner",
                        Url = new Uri("https://www.linkedin.com/in/rfagner/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Github",
                        Url = new Uri("https://github.com/rfagner")
                    }
                });

                // Adicionar configurações ectras da documentação, para ler os XMLs
                var xmlArquivo = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlArquivo));

            });

           // Conexão com o Banco de Dados
            services.AddDbContext<PetLoveContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            // Adicionamos a injeção de dependência
            services.AddTransient<PetLoveContext, PetLoveContext>();
            services.AddTransient<IConsultaRepository, ConsultaRepository>();
            services.AddTransient<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetLove.API v1"));
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
