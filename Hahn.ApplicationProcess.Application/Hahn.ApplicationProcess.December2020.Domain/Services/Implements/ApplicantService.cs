using Hahn.ApplicationProcess.December2020.Data.Entites;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts;
using Hahn.ApplicationProcess.December2020.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Domain.Services.Implements {
    public class ApplicantService : BaseService<Applicant, IApplicantRepository>, IApplicantService {
        private readonly IApplicantRepository _applicantDBContext;
        public ApplicantService(IApplicantRepository applicantDBContext) : base(applicantDBContext) {
            _applicantDBContext = applicantDBContext;
        }
    }
}