using FluentValidation;
using SmartIntranet.DTO.DTOs.CategoryNewsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CategoryNewsAddValidator : AbstractValidator<CategoryNewsAddDto>
    {
        public CategoryNewsAddValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage("Başlıq boş ola bilməz");
            RuleFor(I => I.CategoriesId).NotNull().WithMessage("Kateqoriya boş ola bilməz");
        }
    }
}
