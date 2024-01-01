using DotnetBootcampProje.Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Service.Validations
{
    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Öğrenci adı boş olamaz.")
               .NotNull().WithMessage("Öğrenci adı null olamaz.");

            RuleFor(x => x.Number).NotEmpty().WithMessage("Öğrenci Numarası boş olamaz.")
                  .NotNull().WithMessage("Öğrenci adı null olamaz.");
        }
    }
}
