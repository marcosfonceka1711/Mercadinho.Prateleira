using Mercadinho.Prateleira.Infrastructure.Data.DataRegistration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration collection)
        {
            this._configuration = collection;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Ignora referências Ciclicas.
            services.AddControllers().AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDataRegistration(_configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mercadinho.Prateleira.API",
                    Description = "API CRUD para gestão de prateleira do Mercadinho - Projeto do Curso Introdução ao Entity Framework - Digital Inovation One",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Marcos Roberto da Fonseca",
                        Email = "marcosfonceka@gmail.com",
                        Url = new Uri("https://github.com/marcosfonceka1711"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prateleira API");
                    //c.RoutePrefix = string.Empty;
                }
                ) ; 
                

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
