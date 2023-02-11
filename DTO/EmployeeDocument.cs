using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDocument : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Document { get; set; }
        public string AttachmentType { get; set; }
        public string PassportCopy { get; set; }
        public string Notes { get; set; }
    }
    public class EmployeeDocumentValidator : AbstractValidator<EmployeeDocument>
    {
        public EmployeeDocumentValidator()
        {
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Document).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.AttachmentType).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.PassportCopy).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
        }
    }
    
}
