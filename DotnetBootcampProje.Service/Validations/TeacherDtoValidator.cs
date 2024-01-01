using DotnetBootcampProje.Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProje.Service.Validations
{
    public class TeacherDtoValidator : AbstractValidator<TeacherDto>
    {
        public TeacherDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Öğretmen adı boş olamaz.")
                .NotNull().WithMessage("Öğretmen adı null olamaz!")
                .MaximumLength(50).WithMessage("Öğretmen adı en fazla 50 karakter olabilir. ");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş geçilemez.")
                .NotNull().WithMessage("Email null olamaz.")
                .EmailAddress().WithMessage("Geçeri bir e-posta adresi giriniz.");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon boş geçilemez.")
                .NotNull().WithMessage("Telefon null olamaz.");
        }
    }
}
