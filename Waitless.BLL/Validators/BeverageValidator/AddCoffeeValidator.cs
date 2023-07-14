using FluentValidation;
using Waitless.DTO.BeverageDtos;

namespace Waitless.BLL.Validators.BeverageValidator;

public class AddCoffeeValidator : AbstractValidator<AddBeverageDto> 
{
    public AddCoffeeValidator()
    {
        RuleForEach(x => x.Translations)
            .ChildRules(name =>
                name.RuleFor(x => x.Name)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(20))
            .ChildRules(description =>
                description.RuleFor(x => x.Description)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(256));
                
    }
}
