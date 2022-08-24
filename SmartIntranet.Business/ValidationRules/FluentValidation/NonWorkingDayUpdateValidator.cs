﻿using FluentValidation;
using SmartIntranet.DTO.DTOs.DepartmentDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class NonWorkingDayUpdateValidator : AbstractValidator<NonWorkingDayUpdateDto>
    {
        public NonWorkingDayUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.StartDate).NotNull().WithMessage("Tarix boş ola bilməz");
            RuleFor(I => I.Type).NotNull().WithMessage("Növ boş ola bilməz");
        }
    }
}
