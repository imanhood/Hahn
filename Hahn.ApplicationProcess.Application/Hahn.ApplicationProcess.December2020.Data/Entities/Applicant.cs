using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hahn.ApplicationProcess.December2020.Data.Entites {
    public class Applicant : BaseEntity {
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string FamilyName { get; set; }
        [StringLength(1024)]
        public string Address { get; set; }
        [StringLength(128)]
        public string CountryOfOrigin { get; set; }
        [StringLength(256)]
        public string EmailAdress { get; set; }
        public byte Age { get; set; }
        public bool Hired { get; set; } = false;
    }
}
