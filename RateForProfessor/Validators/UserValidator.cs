using FluentValidation;
using RateForProfessor.Models;

namespace RateForProfessor.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(u => u.Surname)
                .NotEmpty()
                .WithMessage("Surname is required");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.");

            RuleFor(u => u.Role)
                .IsInEnum();

        }

       
    }
}
