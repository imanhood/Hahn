﻿using AutoMapper;
using Hahn.ApplicationProcess.December2020.Data.Entites;
using Hahn.ApplicationProcess.December2020.Domain.Services.Contracts;
using Hahn.ApplicationProcess.December2020.Domain.Services.Implements;
using Hahn.ApplicationProcess.December2020.Web.Models.Binding;
using Hahn.ApplicationProcess.December2020.Web.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Hahn.ApplicationProcess.December2020.Web.Controllers.Api {
    public class ApplicantApiController : BaseApiController<ApplicantApiController, ApplicantBindingModel, ApplicantViewModel, Applicant, IApplicantService> {
        public ApplicantApiController(
                ILogger<ApplicantApiController> logger,
                IApplicantService applicantService,
                IMapper mapper
        ) : base(logger, applicantService, mapper, "Applicants") {}
    }
}