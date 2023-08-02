using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeEmergencyContact : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public string Relationship { get; set; }
        public int EmployeeId { get; set; }
    }

    public class EmployeeEmergencyContactValidator : AbstractValidator<EmployeeEmergencyContact>
    {
        public EmployeeEmergencyContactValidator()
        {
            RuleFor(p => p.Mobile).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Order).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.IsActive).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Relationship).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
        }
    }
}
