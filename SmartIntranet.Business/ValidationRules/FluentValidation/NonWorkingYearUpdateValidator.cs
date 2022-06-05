using FluentValidation;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class NonWorkingYearUpdateValidator : AbstractValidator<NonWorkingYearUpdateDto>
    {
        public NonWorkingYearUpdateValidator()
        {
            RuleFor(I => I.Year).NotNull().WithMessage("İl boş ola bilməz");
        }
    }
}
