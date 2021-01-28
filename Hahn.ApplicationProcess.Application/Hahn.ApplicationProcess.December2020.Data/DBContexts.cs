using Hahn.ApplicationProcess.December2020.Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.December2020.Data {
    public class DBContexts : DbContext {
        public DBContexts(DbContextOptions<DBContexts> option) : base(option) { }
        public virtual DbSet<Applicant> Applicants { get; set; }
    }
}