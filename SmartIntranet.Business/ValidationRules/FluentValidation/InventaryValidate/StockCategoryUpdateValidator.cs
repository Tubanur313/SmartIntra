using FluentValidation;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockCategoryDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.InventaryValidate
{
    public class StockCategoryUpdateValidator : AbstractValidator<StockCategoryUpdateDto>
    {
        public StockCategoryUpdateValidator()
        {

        }
    }
}
