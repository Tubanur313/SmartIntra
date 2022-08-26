using FluentValidation;
using SmartIntranet.DTO.DTOs.ContractDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class ContractUpdateValidator : AbstractValidator<ContractUpdateDto>
    {
        public ContractUpdateValidator()
        {
            RuleFor(I => I.ContractNumber).NotNull().WithMessage("Müqavilə nömrəsi boş ola bilməz");
            RuleFor(I => I.ContractStart).NotNull().WithMessage("Müqavilə tarixi boş ola bilməz");
        }
    }
}
