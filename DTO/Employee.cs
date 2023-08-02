<<<<<<< HEAD
﻿namespace DTO
{
    public class Employee : BaseEntity 
    {
        public string FirstName { get; set; }
        public string Mobile { get; set; }
        public String Email { get; set; }
    }

}
=======
﻿

using FluentValidation;

namespace DTO
{
    public class Employee : BaseEntity
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public string ForeignFirstName { get; set; }
        public string ForeignSecondNamee { get; set; }
        public string ForeignThirdNamee { get; set; }
        public string ForeignLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public String Email { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public string SecondSecurityNO { get; set; }
        public string MaterialStatus { get; set; }
        public bool NoBrothersAllowed { get; set; }
    }

    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.SecondName).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.ThirdName).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Mobile).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.DateOfBirth).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Gender).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.Nationality).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.PassportNumber).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.MaterialStatus).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.NoBrothersAllowed).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(p => p.MotherName).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");

        }
    }
}
>>>>>>> 7f5fe51 (Added my project)
