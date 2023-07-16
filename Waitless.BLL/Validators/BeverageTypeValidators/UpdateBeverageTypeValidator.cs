// using FluentValidation;
// using Waitless.DTO.CoffeeTypeDtos;
//
// namespace Waitless.BLL.Validators.BeverageTypeValidators;
//
// public class UpdateBeverageTypeValidator : AbstractValidator<UpdateCoffeeTypeDto>
// {
//     public UpdateBeverageTypeValidator()
//     {
//         RuleForEach(x => x.Translations)
//           .ChildRules(name =>
//               name.RuleFor(x => x.Name)
//                   .MaximumLength(256)
//                   .MinimumLength(4)
//                   .NotEmpty()
//                   .NotNull()
//                   .WithMessage("{CollectionIndex} cant be empty"))
//           .ChildRules(languageId =>
//               languageId.RuleFor(x => x.LanguageId)
//                   .NotNull()
//                   .WithMessage("{CollectionIndex} cant be null"));
//     }
// }
