using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeEducation : BaseEntity
    {
        public string Major { get; set; }
        public string EducationLevel { get; set; }
        public string EducationCertificate { get; set; }
        public string InsitutationName { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmployeeId { get; set; }
    }

    public class EmployeeEducationValidator : AbstractValidator<EmployeeEducation>
    {
        public EmployeeEducationValidator()
        {
            RuleFor(p => p.Major).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.EducationLevel).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.EducationCertificate).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.InsitutationName).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Address).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.StartDate).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.EndDate).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");

        }
    }



}
