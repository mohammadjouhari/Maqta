using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeExperience : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobDescription { get; set; }
        public string CompanyPhone { get; set; }
        public String CertificationExperince { get; set; }
        public int EmployeeId { get; set; }
        public bool IsAllowedToCallCopmany { get; set; }

        public string TestAddingPropert { get; set; }
    }
    public class EmployeeExperienceValidator : AbstractValidator<EmployeeExperience>
    {
        public EmployeeExperienceValidator()
        {
            RuleFor(p => p.CertificationExperince).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.StartDate).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.EndDate).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Position).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.IsAllowedToCallCopmany).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
        }
    }

}
