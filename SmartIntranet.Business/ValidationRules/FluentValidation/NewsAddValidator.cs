using FluentValidation;
using SmartIntranet.DTO.DTOs.NewsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class NewsAddValidator : AbstractValidator<NewsAddDto>
    {
        public NewsAddValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage("Başlıq boş ola bilməz");
            RuleFor(I => I.CategoriesId).NotNull().WithMessage("Kateqoriya boş ola bilməz");
            //RuleFor(I => I.Description).NotNull().WithMessage("Məzmun boş ola bilməz");
        }
    }
}
