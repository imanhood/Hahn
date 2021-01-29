using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hahn.ApplicationProcess.December2020.Web.Configuration;
using Hahn.ApplicationProcess.December2020.Web.Models.Binding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Web {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvcCore().AddFluentValidation();
            services.AddControllers();
            services.AddCustomServices();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.ApplicationProcess.December2020.Web", Version = "v1" });
            });
            var mapperConfig = new MapperConfiguration(mc => {
                foreach(var p in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                        .Where(x => x.BaseType == typeof(Profile) && x.GetConstructor(Type.EmptyTypes) != null)
                        .Select(x => (Profile)Activator.CreateInstance(x))) {
                    mc.AddProfile(p);
                }
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicationProcess.December2020.Web v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}