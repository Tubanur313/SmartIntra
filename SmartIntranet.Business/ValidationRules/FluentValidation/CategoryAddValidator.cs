using FluentValidation;
using SmartIntranet.DTO.DTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
