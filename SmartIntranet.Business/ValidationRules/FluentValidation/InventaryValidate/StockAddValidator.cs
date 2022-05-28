using FluentValidation;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.InventaryValidate
{
    public class StockAddValidator : AbstractValidator<StockAddDto>
    {
        public StockAddValidator()
        {

        }
    }
}
