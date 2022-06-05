using FluentValidation;
using SmartIntranet.DTO.DTOs.ClauseDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class UserExperienceValidator : AbstractValidator<UserExperience>
    {
        public UserExperienceValidator()
        {
            RuleFor(I => I.ExperienceStart).NotNull().WithMessage("Başlama tarixi boş ola bilməz");
            RuleFor(I => I.ExperienceEnd).NotNull().WithMessage("Bitmə tarixi boş ola bilməz");
        }
    }
}
