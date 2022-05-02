using FluentValidation;
using SmartIntranet.DTO.DTOs.DiscussionDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class DiscussionAddValidator : AbstractValidator<DiscussionAddDto>
    {
        public DiscussionAddValidator()
        {
        }
    }
}
