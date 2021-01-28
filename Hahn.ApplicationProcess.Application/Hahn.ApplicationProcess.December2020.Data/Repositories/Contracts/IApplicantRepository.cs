using Hahn.ApplicationProcess.December2020.Data.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.December2020.Data.Repositories.Contracts {
    public interface IApplicantRepository : IBaseRepository<Applicant, DBContexts> {
    }
}
