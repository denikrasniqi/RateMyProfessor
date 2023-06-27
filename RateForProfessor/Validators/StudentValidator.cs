using FluentValidation;
using RateForProfessor.Models;

namespace RateForProfessor.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator() 
        {
            RuleFor(s => s.Name)
           .NotEmpty()
           .WithMessage("Name is required");

            RuleFor(s => s.Surname)
           .NotEmpty()
           .WithMessage("Surname is required");

            RuleFor(s => s.Email)
           .EmailAddress()
           .WithMessage("Email is required");

            RuleFor(s => s.Password)
           .NotEmpty()
           .WithMessage("Password is required")
           .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
           .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
           .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
           .Matches("[0-9]").WithMessage("Password must contain at least one digit.");


            RuleFor(s => s.Grade)
           .NotEmpty()
           .WithMessage("Grade is required");

           // = RuleFor(s => s.Gender)
           //.NotEmpty()
           //.WithMessage("Gender is required");
        }
    }
}
