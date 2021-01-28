using AutoMapper;
using Hahn.ApplicationProcess.December2020.Data;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Implements;
using Hahn.ApplicationProcess.December2020.Domain.Services.Contracts;
using Hahn.ApplicationProcess.December2020.Domain.Services.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Web.Configuration {
    public static class AddCustomServicesExtensions {
        public static IServiceCollection AddCustomServices(this IServiceCollection services) {
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            var mapperConfig = new MapperConfiguration(mc => {
                foreach(var p in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                        .Where(x => x.BaseType == typeof(Profile) && x.GetConstructor(Type.EmptyTypes) != null)
                        .Select(x => (Profile)Activator.CreateInstance(x))) {
                    mc.AddProfile(p);
                }
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContext<DBContexts>(x=> x.UseInMemoryDatabase("Test"), ServiceLifetime.Singleton);
            return services;
        }
    }
}