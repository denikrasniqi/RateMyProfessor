using FluentValidation;
using RateForProfessor.Models;

namespace RateForProfessor.Validators
{
    public class UniversityValidator: AbstractValidator<University>
    {
        public UniversityValidator()
        {
            RuleFor(u => u.Name)
           .NotEmpty()
           .WithMessage("Name name is required");

            RuleFor(u => u.EstablishedYear).
            GreaterThanOrEqualTo(1)
           .WithMessage("Established Year is required");

            RuleFor(u => u.Description)
            .NotEmpty()
            .WithMessage("Description is required");

            RuleFor(u => u.StaffNumber)
           .GreaterThanOrEqualTo(1)
           .WithMessage("Staff Number should be greated than 0");

            RuleFor(u => u.StudentsNumber)
           .GreaterThanOrEqualTo(1)
           .WithMessage("Students Number should be greated than 0");

            RuleFor(s => s.CoursesNumber)
           .GreaterThanOrEqualTo(1)
           .WithMessage("Courses Number should be greated than 0");

        }
    }
}
