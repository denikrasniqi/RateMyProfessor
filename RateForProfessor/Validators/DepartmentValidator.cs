using FluentValidation;
using RateForProfessor.Models;

namespace RateForProfessor.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(s => s.Name)
           .NotEmpty()
           .WithMessage("Department name is required");

            RuleFor(s => s.EstablishedYear)
           .NotEmpty()
           .WithMessage("Established year is required");

            RuleFor(s => s.Description)
           .NotEmpty()
           .WithMessage("Description is required");

            RuleFor(s => s.StaffNumber)
           .NotEmpty()
           .WithMessage("Staff number is required");

            RuleFor(s => s.StudentNumber)
           .NotEmpty()
           .WithMessage("Student number is required");

            RuleFor(s => s.CourseNumber)
           .NotEmpty()
           .WithMessage("Course number is required");
        }
    }
}
