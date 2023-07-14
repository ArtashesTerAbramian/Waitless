using Waitless.DTO.OrderDtos;
using FluentValidation;

namespace Waitless.BLL.Validators.OrderValidators;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderValidator()
    {
        
    }
}
