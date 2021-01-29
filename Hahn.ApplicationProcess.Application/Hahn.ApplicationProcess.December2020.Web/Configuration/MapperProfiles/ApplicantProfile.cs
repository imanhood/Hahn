using AutoMapper;
using Hahn.ApplicationProcess.December2020.Data.Entites;
using Hahn.ApplicationProcess.December2020.Web.Models.Binding;
using Hahn.ApplicationProcess.December2020.Web.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Web.Configuration.Mappers {
    public class ApplicantProfile : Profile {
        public ApplicantProfile() {
            CreateMap<Applicant, ApplicantViewModel>();
            CreateMap<ApplicantBindingModel, Applicant>();
        }
    }
}