using FluentValidation;
namespace DTO
{
    public class EmployeeBank : BaseEntity
    {
        public int EmployeeId { get; set; }

        public int BankId { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Iban { get; set; }

    }
    public class EmployeeBankValidator : AbstractValidator<EmployeeBank>
    {
        public EmployeeBankValidator()
        {
            RuleFor(p => p.Iban).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.IsActive).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
        }
    }
}
