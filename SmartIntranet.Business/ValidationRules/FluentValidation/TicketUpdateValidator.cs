using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class TicketUpdateValidator : AbstractValidator<TicketUpdateDto>
    {
        public TicketUpdateValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage("Başlıq boş ola bilməz");
            RuleFor(I => I.CategoryTicketId).NotNull().WithMessage("Kateqoriya boş ola bilməz");
            RuleFor(I => I.PriorityType).NotNull().WithMessage("Öncəllik boş ola bilməz");
            RuleFor(I => I.StatusType).NotNull().WithMessage("Status boş ola bilməz");
        }
    }
}
