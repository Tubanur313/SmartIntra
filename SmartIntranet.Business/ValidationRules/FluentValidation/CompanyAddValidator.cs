using FluentValidation;
using SmartIntranet.DTO.DTOs.CompanyDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CompanyAddValidator:AbstractValidator<CompanyAddDto>
    {
        public CompanyAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Şirkət adı boş ola bilməz!");
        }
    }
}
