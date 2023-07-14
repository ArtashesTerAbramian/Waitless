using FluentValidation;
using Waitless.DTO.BeverageTypeDtos;

namespace Waitless.BLL.Validators.BeverageCategoryValidators;

public class UpdateCoffeeCategoryValidation : AbstractValidator<UpdateBeverageTypeDto>
{
    public UpdateCoffeeCategoryValidation()
    {
        RuleForEach(x => x.Translations)
            .ChildRules(name =>
                name.RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("{CollectionIndex} cant be empty"));
    }
}