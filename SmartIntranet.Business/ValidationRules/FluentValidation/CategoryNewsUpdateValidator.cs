using FluentValidation;
using SmartIntranet.DTO.DTOs.CategoryNewsDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CategoryNewsUpdateValidator : AbstractValidator<CategoryNewsUpdateDto>
    {
        public CategoryNewsUpdateValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage("Başlıq boş ola bilməz");
        }
    }
}
