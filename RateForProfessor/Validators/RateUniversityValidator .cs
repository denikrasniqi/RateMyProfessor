using FluentValidation;
using FluentValidation.AspNetCore;
using RateForProfessor.Models;
using System.Data;

namespace RateForProfessor.Validators
{
    public class RateUniversityValidator : AbstractValidator<RateUniversity>
    {
        public RateUniversityValidator()
        {
            RuleFor(u => u.Overall)
            .NotEmpty()
            .WithMessage("Overall is required")
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(5)
            .WithMessage("Overall must be between or equal to 1-5");

            RuleFor(s => s.Feedback)
            .NotEmpty()
            .WithMessage("Feedback is required");
        }
    }
}
