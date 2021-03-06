using FluentValidation;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class DepartmentAddValidator : AbstractValidator<DepartmentAddDto>
    {
        public DepartmentAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
        }
    }
}
