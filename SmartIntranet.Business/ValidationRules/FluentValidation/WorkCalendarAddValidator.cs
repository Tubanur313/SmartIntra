using FluentValidation;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WorkCalendarAddValidator : AbstractValidator<WorkCalendarAddDto>
    {
        public WorkCalendarAddValidator()
        {
            RuleFor(I => I.Number).NotNull().WithMessage("İş saatı boş ola bilməz");
        }
    }
}
