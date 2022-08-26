using FluentValidation;
using SmartIntranet.DTO.DTOs.CompanyDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CompanyUpdateValidator : AbstractValidator<CompanyUpdateDto>
    {
        public CompanyUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.LeaderId).NotNull().WithMessage("Rəhbər boş ola bilməz");
            RuleFor(I => I.LeaderPosition).NotNull().WithMessage("Şirkətin rəhbərinin vəzifəsi boş ola bilməz");
            RuleFor(I => I.Tin).NotNull().WithMessage("Şirkətin VÖEN-i boş ola bilməz");
            RuleFor(I => I.Address).NotNull().WithMessage("Şirkətin hüquqi ünvanı boş ola bilməz");
            RuleFor(I => I.BankAccountNumber).NotNull().WithMessage("Şirkətin bank hesabının nömrəsi boş ola bilməz");
            RuleFor(I => I.BankName).NotNull().WithMessage("Bankın adı boş ola bilməz");
            RuleFor(I => I.BankTin).NotNull().WithMessage("Bankın VÖEN-i boş ola bilməz");
            RuleFor(I => I.BankCode).NotNull().WithMessage("Bankın kodu boş ola bilməz");
            RuleFor(I => I.SWIFTCode).NotNull().WithMessage("Bankın SWIFT kodu boş ola bilməz");
            RuleFor(I => I.CorrespondentAccountNumber).NotNull().WithMessage("Müxbir hesabının nömrəsi boş ola bilməz");
        }
    }
}
