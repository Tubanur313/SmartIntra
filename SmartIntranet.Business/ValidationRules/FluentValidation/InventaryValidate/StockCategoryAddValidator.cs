using FluentValidation;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockCategoryDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.InventaryValidate
{
    public class StockCategoryAddValidator : AbstractValidator<StockCategoryAddDto>
    {
        public StockCategoryAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
