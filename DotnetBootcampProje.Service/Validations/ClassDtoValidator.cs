using DotnetBootcampProje.Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Service.Validations
{
    public class ClassDtoValidator : AbstractValidator<ClassDto>
    {
        public ClassDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Sınıf adı null geçilemez.").NotEmpty().WithMessage("Sınıf adı boş geçilemez");
        }
    }
}
