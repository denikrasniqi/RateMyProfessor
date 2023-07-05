using FluentValidation;
using RateForProfessor.Models;

namespace RateForProfessor.Validators
{
    public class RateProfessorValidator : AbstractValidator<RateProfessor>
    {
        public RateProfessorValidator()
        {
            RuleFor(s => s.Overall)
           .NotEmpty()
           .WithMessage("Overall is required")
           .GreaterThanOrEqualTo(1)
           .LessThanOrEqualTo(5)
           .WithMessage("Overall must be between or equal to 1-5");

            RuleFor(s => s.GradingFairness)
           .NotEmpty()
           .WithMessage("GradingFairness is required")
           .GreaterThanOrEqualTo(1)
           .LessThanOrEqualTo(5)
           .WithMessage("GradingFairness must be between or equal to 1-5");

            RuleFor(s => s.CommunicationSkills)
           .NotEmpty()
           .WithMessage("CommunicationSkills is required")
           .GreaterThanOrEqualTo(1)
           .LessThanOrEqualTo(5)
           .WithMessage("CommunicationSkills must be between or equal to 1-5");

            RuleFor(s => s.Feedback)
           .NotEmpty()
           .WithMessage("Feedback is required");
        }
    }
}
