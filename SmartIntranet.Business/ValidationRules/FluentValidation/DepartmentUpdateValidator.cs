﻿using FluentValidation;
using SmartIntranet.DTO.DTOs.DepartmentDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class DepartmentUpdateValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
        }
    }
}
