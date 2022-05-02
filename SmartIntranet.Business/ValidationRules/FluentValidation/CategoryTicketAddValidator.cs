using FluentValidation;
using SmartIntranet.DTO.DTOs.CategoryDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CategoryTicketAddValidator : AbstractValidator<CategoryTicketAddDto>
    {
        public CategoryTicketAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.TicketType).NotNull().WithMessage("Tiketin növü boş ola bilməz");
        }
    }
}
