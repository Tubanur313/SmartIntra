using FluentValidation;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.DTO.DTOs.PersonalContractDto;
using SmartIntranet.DTO.DTOs.WorkGraphicDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class PersonalContractAddValidator : AbstractValidator<PersonalContractAddDto>
    {
        public PersonalContractAddValidator()
        {
            RuleFor(I => I.UserId).NotNull().WithMessage("Əməkdaş boş ola bilməz");
            RuleFor(I => I.Type).NotNull().WithMessage("Növ boş ola bilməz");
            RuleFor(I => I.CommandNumber).NotNull().WithMessage("Sənəd nömrəsi boş ola bilməz");
            RuleFor(I => I.CommandDate).NotNull().WithMessage("Sənəd tarixi boş ola bilməz");
        }
    }
}
