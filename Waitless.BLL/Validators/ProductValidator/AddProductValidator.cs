using FluentValidation;
using Waitless.DTO.ProductDtos;

namespace Waitless.BLL.Validators.ProductValidator;

public class AddProductValidator : AbstractValidator<AddProductDto> 
{
    public AddProductValidator()
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
