using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeLanguage : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int LanguaqgeId { get; set; }
    }
    public class EmployeeLanguageValidator : AbstractValidator<EmployeeLanguage>
    {
        public EmployeeLanguageValidator()
        {
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.LanguaqgeId).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
        }
    }
}
