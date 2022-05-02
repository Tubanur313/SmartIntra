using FluentValidation;
using SmartIntranet.DTO.DTOs.WatcherDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WatcherUpdateValidator : AbstractValidator<WatcherUpdateDto>
    {
        public WatcherUpdateValidator()
        {
        }
    }
}
