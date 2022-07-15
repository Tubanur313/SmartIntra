using FluentValidation;
using SmartIntranet.DTO.DTOs.ArchiveDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.ArchiveValidate
{
    public class ArchiveAddValidator : AbstractValidator<ArchiveAddDto>
    {
        public ArchiveAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
