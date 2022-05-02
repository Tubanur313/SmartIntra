using FluentValidation;
using SmartIntranet.DTO.DTOs.EntranceDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class EntranceListValidator : AbstractValidator<EntranceListDto>
    {
        public EntranceListValidator()
        {
        }
    }
}
