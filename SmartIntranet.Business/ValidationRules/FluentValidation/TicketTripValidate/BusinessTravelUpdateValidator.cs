using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketTripDtos.BusinessTravelDtos;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.TicketTripValidate
{
    public class BusinessTravelUpdateValidator : AbstractValidator<BusinessTravelUpdateDto>
    {
        public BusinessTravelUpdateValidator()
        {
            //RuleFor(I => I.BusinessTravelPlaceId).NotNull().WithMessage("Ezamiyyət Yeri boş ola bilməz");
            RuleFor(I => I.CauseId).NotNull().WithMessage("Ezamiyyət Əsası boş ola bilməz");
            RuleFor(I => I.StartDate).NotNull().WithMessage("Ezamiyyət Başlama Tarixi boş ola bilməz");
            RuleFor(I => I.EndDate).NotNull().WithMessage("Ezamiyyət Bitmə Tarixi boş ola bilməz");
        }
    }
}
