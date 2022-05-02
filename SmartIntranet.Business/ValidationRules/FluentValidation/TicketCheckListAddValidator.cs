using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketCheckListDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class TicketCheckListAddValidator : AbstractValidator<TicketCheckListAddDto>
    {
        public TicketCheckListAddValidator()
        {
        }
    }
}
