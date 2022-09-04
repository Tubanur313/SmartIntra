using FluentValidation;
using SmartIntranet.DTO.DTOs.ArchiveDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.ArchiveValidate
{
    public class ArchiveUpdateValidator : AbstractValidator<ArchiveUpdateDto>
    {
        public ArchiveUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
            RuleFor(I => I.DepartmentId).NotNull().WithMessage("Şöbə boş ola bilməz");
        }
    }
}
