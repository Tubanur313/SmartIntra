using FluentValidation;
using SmartIntranet.DTO.DTOs.BusinessTripDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class BusinessTripAddValidator : AbstractValidator<BusinessTripAddDto>
    {
        public BusinessTripAddValidator()
        {
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
            RuleFor(I => I.CommandNumber).NotNull().WithMessage("Sənəd nömrəsi boş ola bilməz");
            RuleFor(I => I.CommandDate).NotNull().WithMessage("Sənəd tarixi boş ola bilməz");
            RuleFor(I => I.CauseId).NotNull().WithMessage("Ezamiyyət əsası boş ola bilməz");
        }
    }
}
