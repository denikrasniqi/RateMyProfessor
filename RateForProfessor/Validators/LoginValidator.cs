using FluentValidation;

namespace RateForProfessor.Validators
{
    public class LoginValidator : AbstractValidator<(string email, string password)>
    {
        public LoginValidator()
        {
            RuleFor(login => login.email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(login => login.password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}