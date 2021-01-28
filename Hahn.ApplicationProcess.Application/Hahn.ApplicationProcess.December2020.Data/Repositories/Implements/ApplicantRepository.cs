using Hahn.ApplicationProcess.December2020.Data.Entites;
using Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories.Implements {
    public class ApplicantRepository : BaseRepository<Applicant, DBContexts>, IApplicantRepository {
        public ApplicantRepository(DBContexts contexts) : base(contexts) {
        }
    }
}