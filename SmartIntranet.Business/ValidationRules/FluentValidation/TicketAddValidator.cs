using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class TicketAddValidator : AbstractValidator<TicketAddDto>
    {
        public TicketAddValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage("Başlıq boş ola bilməz");
            RuleFor(I => I.CategoryId).NotNull().WithMessage("Kateqoriya boş ola bilməz");
            RuleFor(I => I.PriorityType).NotNull().WithMessage("Öncəllik boş ola bilməz");
            RuleFor(I => I.StatusType).NotNull().WithMessage("Status boş ola bilməz");
        }
    }
}
