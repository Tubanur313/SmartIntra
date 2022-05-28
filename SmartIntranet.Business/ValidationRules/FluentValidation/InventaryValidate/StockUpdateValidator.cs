using FluentValidation;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.InventaryValidate
{
    public class StockUpdateValidator : AbstractValidator<StockUpdateDto>
    {
        public StockUpdateValidator()
        {

        }
    }
}
