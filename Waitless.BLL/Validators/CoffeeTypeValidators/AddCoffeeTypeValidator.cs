using Waitless.DTO.CoffeeTypeDtos;
using FluentValidation;

namespace Waitless.BLL.Validators.CoffeeTypeValidators;

public class AddCoffeeTypeValidator : AbstractValidator<AddCoffeeTypeDto>
{
    public AddCoffeeTypeValidator()
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
