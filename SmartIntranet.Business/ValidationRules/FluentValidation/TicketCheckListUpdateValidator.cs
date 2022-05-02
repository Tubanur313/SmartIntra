using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketCheckListDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class TicketCheckListUpdateValidator : AbstractValidator<TicketCheckListUpdateDto>
    {
        public TicketCheckListUpdateValidator()
        {
        }
    }
}
