using FluentValidation;
using RateForProfessor.Models;

namespace RateForProfessor.Validators
{
    public class ProfessorValidator : AbstractValidator<Professor>
    {
        public ProfessorValidator()
        {
            RuleFor(s => s.FirstName)
           .NotEmpty()
           .WithMessage("First name is required");

            RuleFor(s => s.LastName)
           .NotEmpty()
           .WithMessage("Last name is required");

            RuleFor(s => s.Email)
           .EmailAddress()
           .WithMessage("Email is required");

            RuleFor(s => s.Education)
           .NotEmpty()
           .WithMessage("Education is required");

            RuleFor(s => s.Role)
           .NotEmpty()
           .WithMessage("Role is required");
        }
    }
}
