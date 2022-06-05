using FluentValidation;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class NonWorkingYearAddValidator : AbstractValidator<NonWorkingYearAddDto>
    {
        public NonWorkingYearAddValidator()
        {
            RuleFor(I => I.Year).NotNull().WithMessage("İl boş ola bilməz");
        }
    }
}
