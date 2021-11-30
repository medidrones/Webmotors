using FluentValidation;
using Webmotors.Domain.Interfaces.Requests;

namespace Webmotors.Domain.Validators
{
    public class AdValidator : AbstractValidator<IAdRequest>
    {
        public AdValidator()
        {
            RuleFor(x => x.Make).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Model).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Version).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Year).NotNull();
            RuleFor(x => x.Mileage).NotNull();
            RuleFor(x => x.Note).NotEmpty();
        }
    }
}
