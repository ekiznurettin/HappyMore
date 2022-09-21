using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<User>
    {
       public ProductValidator()
        {
            //RuleFor(p => p.ProductName).NotEmpty();
            //RuleFor(p => p.ProductName).Length(2, 30);
            //RuleFor(p => p.UnitPrice).NotEmpty();
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //RuleFor(p => p.ProductName).Must(StartWithWithA);
            //RuleFor(p => p.QuantityPerUnit).NotEmpty();
            //RuleFor(p => p.UnitsInStock).NotEmpty();
        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
