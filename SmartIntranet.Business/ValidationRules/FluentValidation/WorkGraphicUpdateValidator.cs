using FluentValidation;
using SmartIntranet.DTO.DTOs.WorkGraphicDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WorkGraphicUpdateValidator : AbstractValidator<WorkGraphicUpdateDto>
    {
        public WorkGraphicUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.NonWorkingYearId).NotNull().WithMessage("İl boş ola bilməz");
        }
    }
}
