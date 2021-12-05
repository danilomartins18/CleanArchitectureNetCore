using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty().MinimumLength(10).MaximumLength(50);
        }
    }
}
