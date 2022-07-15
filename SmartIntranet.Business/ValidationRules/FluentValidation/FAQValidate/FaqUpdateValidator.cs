using FluentValidation;
using SmartIntranet.DTO.DTOs.FaqDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.FAQValidate
{
    public class FaqUpdateValidator : AbstractValidator<FaqUpdateDto>
    {
        public FaqUpdateValidator()
        {
            RuleFor(I => I.Question).NotNull().WithMessage("Sual boş ola bilməz");
            RuleFor(I => I.Answer).NotNull().WithMessage("Cavab boş ola bilməz");
            RuleFor(I => I.FaqCategory).NotNull().WithMessage("Kateqoriya boş ola bilməz");
        }
    }
}
