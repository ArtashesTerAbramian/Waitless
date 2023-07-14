using Waitless.DTO.CoffeeDtos;
using FluentValidation;

namespace Waitless.BLL.Validators.CoffeeValidator;

public class AddCoffeeValidator : AbstractValidator<AddCoffeeDto> 
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
