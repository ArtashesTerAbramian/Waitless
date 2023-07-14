using Waitless.DTO.OrderDtos;
using FluentValidation;

namespace Waitless.BLL.Validators.OrderValidators;

public class AddOrderValidator : AbstractValidator<AddOrderDto>
{
    public AddOrderValidator()
    {
        RuleFor(x => x.AddressId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.CoffeeIds) 
            .NotNull()
            .NotEmpty();
    }
}
