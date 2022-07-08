using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketTripDtos.BusinessTravelDtos;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.TicketTripValidate
{
    public class BusinessTravelAddValidator : AbstractValidator<BusinessTravelAddDto>
    {
        public BusinessTravelAddValidator()
        {
            RuleFor(I => I.PlaceId).NotNull().WithMessage("Ezamiyyət Yeri boş ola bilməz");
            RuleFor(I => I.CauseId).NotNull().WithMessage("Ezamiyyət Əsası boş ola bilməz");
            RuleFor(I => I.StartDate).NotNull().WithMessage("Ezamiyyət Başlama Tarixi boş ola bilməz");
            RuleFor(I => I.EndDate).NotNull().WithMessage("Ezamiyyət Bitmə Tarixi boş ola bilməz");
        }
    }
}
