using FluentValidation;
using SmartIntranet.DTO.DTOs.BusinessTripDto;
using SmartIntranet.DTO.DTOs.CauseDto;
using SmartIntranet.DTO.DTOs.ClauseDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class BusinessTripUpdateValidator : AbstractValidator<BusinessTripUpdateDto>
    {
        public BusinessTripUpdateValidator()
        {
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
            RuleFor(I => I.CommandNumber).NotNull().WithMessage("Sənəd nömrəsi boş ola bilməz");
            RuleFor(I => I.CommandDate).NotNull().WithMessage("Sənəd tarixi boş ola bilməz");
            RuleFor(I => I.CauseId).NotNull().WithMessage("Ezamiyyət əsası boş ola bilməz");
        }
    }
}
