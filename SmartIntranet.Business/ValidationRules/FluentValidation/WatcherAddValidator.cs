using FluentValidation;
using SmartIntranet.DTO.DTOs.WatcherDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WatcherAddValidator : AbstractValidator<WatcherAddDto>
    {
        public WatcherAddValidator()
        {
        }
    }
}
