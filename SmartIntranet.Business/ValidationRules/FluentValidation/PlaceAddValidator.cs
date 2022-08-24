using FluentValidation;
using SmartIntranet.DTO.DTOs.PlaceDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class PlaceAddValidator : AbstractValidator<PlaceAddDto>
    {
        public PlaceAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
