using FluentValidation;
using SmartIntranet.DTO.DTOs.NewsDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class NewsUpdateValidator : AbstractValidator<NewsUpdateDto>
    {
        public NewsUpdateValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage("Başlıq boş ola bilməz");
            //RuleFor(I => I.Description).NotNull().WithMessage("Məzmun boş ola bilməz");
        }
    }
}
