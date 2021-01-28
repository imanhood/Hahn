using FluentValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.December2020.Web.Models.Binding {
    public class ApplicantBindingModel : BaseBindingModel {     
        [Required]
        public string Name { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CountryOfOrigin { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public int? Age { get; set; }
        public bool Hired { get; set; } = false;
    }
    public class ApplicantValidator : AbstractValidator<ApplicantBindingModel> {
        public ApplicantValidator() {
            RuleFor(x => x.Name).Length(min: 5, max: 256);
            RuleFor(x => x.FamilyName).Length(min: 5, max: 256);
            RuleFor(x => x.Address).Length(min: 10, max: 1024);
            RuleFor(x => x.CountryOfOrigin).Length(min: 0, max: 128);
            RuleFor(x => x.EmailAdress).EmailAddress().Length(min: 0, max: 256);
            RuleFor(x => x.Age).InclusiveBetween(20, 60);
        }
    }
}