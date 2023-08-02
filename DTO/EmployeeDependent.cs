using FluentValidation;

namespace DTO
{
    public class EmployeeDependent : BaseEntity
    {
        public string Name { get; set; }
        public int RelationshipId { get; set; }
        public int EmployeeId { get; set; }
    }

    public class EmployeeDependentValidator : AbstractValidator<EmployeeDependent>
    {
        public EmployeeDependentValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.RelationshipId).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
        }
    }
}
