using FluentValidation;
using SmartIntranet.DTO.DTOs.CompanyDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CompanyUpdateValidator : AbstractValidator<CompanyUpdateDto>
    {
        public CompanyUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Şirkət adı boş ola bilməz!");
        }
    }
}
