using FluentValidation;
using Waitless.DTO.BeverageTypeDtos;

namespace Waitless.BLL.Validators.BeverageTypeValidators;

public class AddBeverageTypeValidator : AbstractValidator<AddBeverageTypeDto>
{
    public AddBeverageTypeValidator()
    {
        RuleForEach(x => x.Translations)
            .ChildRules(name =>
                name.RuleFor(x => x.Name)
                    .MaximumLength(256)
                    .MinimumLength(4)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("{CollectionIndex} cant be empty"))
            .ChildRules(languageId =>
                languageId.RuleFor(x => x.LanguageId)
                    .NotNull()
                    .WithMessage("{CollectionIndex} cant be null"));
    }
}
