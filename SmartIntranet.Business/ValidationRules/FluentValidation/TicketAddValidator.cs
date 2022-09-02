using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class TicketAddValidator : AbstractValidator<TicketAddDto>
    {
        public TicketAddValidator()
        {
            RuleFor(I => I.BusinessTravelPlaceId).NotNull().WithMessage("Ezamiyyət Yeri boş ola bilməz");
            RuleFor(I => I.Title).NotNull().WithMessage("Başlıq boş ola bilməz");
            RuleFor(I => I.TicketCategoryId).NotNull().WithMessage("Kateqoriya boş ola bilməz");
            RuleFor(I => I.PriorityType).NotNull().WithMessage("Prioritet boş ola bilməz");
            RuleFor(I => I.StatusType).NotNull().WithMessage("Status boş ola bilməz");
        }
    }
}
