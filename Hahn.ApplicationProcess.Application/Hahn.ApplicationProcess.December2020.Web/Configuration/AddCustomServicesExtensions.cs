using FluentValidation;
using Hahn.ApplicationProcess.December2020.Data;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Implements;
using Hahn.ApplicationProcess.December2020.Domain.Services.Contracts;
using Hahn.ApplicationProcess.December2020.Domain.Services.Implements;
using Hahn.ApplicationProcess.December2020.Web.Models.Binding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.December2020.Web.Configuration {
    public static class AddCustomServicesExtensions {
        public static IServiceCollection AddCustomServices(this IServiceCollection services) {
            //Services
            services.AddScoped<IApplicantService, ApplicantService>();

            //Repositories
            services.AddScoped<IApplicantRepository, ApplicantRepository>();

            //DbContexts
            services.AddDbContext<DBContexts>(x=> x.UseInMemoryDatabase("Test"), ServiceLifetime.Singleton);

            //Validator
            services.AddTransient<IValidator<ApplicantBindingModel>, ApplicantValidator>();

            return services;
        }
    }
}