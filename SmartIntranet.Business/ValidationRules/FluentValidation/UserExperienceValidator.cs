using FluentValidation;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class UserExperienceValidator : AbstractValidator<UserExperience>
    {
        public UserExperienceValidator()
        {
            RuleFor(I => I.ExperienceStart).NotNull().WithMessage("Başlama tarixi boş ola bilməz");
            RuleFor(I => I.ExperienceEnd).NotNull().WithMessage("Bitmə tarixi boş ola bilməz");
        }
    }
}
