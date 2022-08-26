using FluentValidation;
using SmartIntranet.DTO.DTOs.VacancyDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class VacancyAddValidator : AbstractValidator<VacancyAddDto>
    {
        public VacancyAddValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage("Vakansiyanın Adı boş ola bilməz");
            RuleFor(I => I.CandidateDesc).NotNull().WithMessage("Tələblər boş ola bilməz");
            RuleFor(I => I.PosDesc).NotNull().WithMessage("Vəzifə öhdəlikləri boş ola bilməz");
            RuleFor(I => I.Salary).NotNull().WithMessage("Əmək haqqı boş ola bilməz");
            RuleFor(I => I.Occupations).NotNull().WithMessage("İş saatları boş ola bilməz");
            RuleFor(I => I.Email).EmailAddress().WithMessage("Email doğru deyil");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət adı boş ola bilməz");
        }
    }
}
