using FluentValidation;
using RateForProfessor.Models;

namespace RateForProfessor.Validators
{
    public class LoginValidator : AbstractValidator<Student>
    {
        public LoginValidator()
        {
            RuleFor(student => student.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");
            
            RuleFor(student => student.Password)
           .NotEmpty()
           .WithMessage("Password is required.")
           .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
        }

    }
}
