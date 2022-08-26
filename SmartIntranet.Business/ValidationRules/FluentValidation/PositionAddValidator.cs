using FluentValidation;
using SmartIntranet.DTO.DTOs.PositionDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class PositionAddValidator : AbstractValidator<PositionAddDto>
    {
        public PositionAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
            RuleFor(I => I.DepartmentId).NotNull().WithMessage("Şöbə boş ola bilməz");
        }
    }
}
