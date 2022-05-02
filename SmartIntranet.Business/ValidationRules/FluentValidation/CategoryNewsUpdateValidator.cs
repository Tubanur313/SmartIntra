using FluentValidation;
using SmartIntranet.DTO.DTOs.CategoryNewsDto;
using SmartIntranet.DTO.DTOs.NewsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CategoryNewsUpdateValidator : AbstractValidator<CategoryNewsUpdateDto>
    {
        public CategoryNewsUpdateValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage("Başlıq boş ola bilməz");
        }
    }
}
