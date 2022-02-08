using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DotNetWebApiPaginationHateoas.Data;
using DotNetWebApiPaginationHateoas.Interfaces;
using DotNetWebApiPaginationHateoas.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotNetWebApiPaginationHateoas
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

            services.AddControllers().
                AddJsonOptions(ops =>
                    {
                        ops.JsonSerializerOptions.IgnoreNullValues = true;
                        ops.JsonSerializerOptions.WriteIndented = true;
                        ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                        ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNetWebApiPaginationHateoas", Version = "v1" });
            });
            services.AddDbContext<HobbyDbContext>(options => options.UseInMemoryDatabase("HobbyDb"));
            services.AddTransient<IHobbyService, HobbyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNetWebApiPaginationHateoas v1"));

                //initialize data seeds
                using var serviceScope = app.ApplicationServices
                                            .GetRequiredService<IServiceScopeFactory>()
                                            .CreateScope();
                var service = serviceScope.ServiceProvider;
                FakeDataSeeder.Seed(service);
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
