﻿using FluentValidation;
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
            RuleFor(I => I.AddedByUserId).NotNull().WithMessage("İstifadəçi boş ola bilməz");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
            RuleFor(I => I.DepartmentId).NotNull().WithMessage("Şöbə boş ola bilməz");
        }
    }
}
