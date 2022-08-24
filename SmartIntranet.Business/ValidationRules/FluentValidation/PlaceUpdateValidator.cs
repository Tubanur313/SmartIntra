using FluentValidation;
using SmartIntranet.DTO.DTOs.PlaceDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class PlaceUpdateValidator : AbstractValidator<PlaceUpdateDto>
    {
        public PlaceUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
