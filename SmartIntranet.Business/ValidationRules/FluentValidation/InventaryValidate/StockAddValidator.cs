using FluentValidation;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.InventaryValidate
{
    public class StockAddValidator : AbstractValidator<StockAddDto>
    {
        public StockAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
            RuleFor(I => I.StockCategoryId).NotNull().WithMessage("Kateqoriya boş ola bilməz");
        }
    }
}
