using FluentValidation;
using SmartIntranet.DTO.DTOs.PersonalContractDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class PersonalContractUpdateValidator : AbstractValidator<PersonalContractUpdateDto>
    {
        public PersonalContractUpdateValidator()
        {
            RuleFor(I => I.UserId).NotNull().WithMessage("Əməkdaş boş ola bilməz");
            RuleFor(I => I.Type).NotNull().WithMessage("Növ boş ola bilməz");
            RuleFor(I => I.CommandNumber).NotNull().WithMessage("Əmr nömrəsi boş ola bilməz");
            RuleFor(I => I.CommandDate).NotNull().WithMessage("Sənəd tarixi boş ola bilməz");
        }
    }
}
