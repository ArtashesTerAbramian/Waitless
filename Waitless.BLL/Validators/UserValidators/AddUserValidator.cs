using Waitless.DTO.UsersDtos;
using FluentValidation;

namespace Waitless.BLL.Validators.UserValidators;

public class AddUserValidator : AbstractValidator<AddUserDto>
{
    public AddUserValidator()
    {
        RuleFor(user => user.Phone)
           .Cascade(CascadeMode.Stop)
           .NotEmpty()
                .WithMessage("Phone number is required.")
           .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")
                .WithMessage("Invalid phone number format.");

        RuleFor(user => user.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithMessage("Email address is required.")
            .EmailAddress()
                .WithMessage("Invalid email address format.");

        RuleFor(user => user.UserName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithMessage("Username is required.")
            .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Username must contain only alphanumeric characters.");
    }
}
