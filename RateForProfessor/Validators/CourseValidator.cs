using FluentValidation;
using RateForProfessor.Models;

namespace RateForProfessor.Validators
{
    public class CourseValidator :AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(s => s.Name)
           .NotEmpty()
           .WithMessage("Course name is required");

            RuleFor(s => s.Code)
           .NotEmpty()
           .WithMessage("Code is required");

            RuleFor(s => s.Description)
           .NotEmpty()
           .WithMessage("Description is required");

            RuleFor(s => s.CreditHours)
           .NotEmpty()
           .WithMessage("Credit Hours are required");
        }
    }
}
