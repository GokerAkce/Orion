using FluentValidation;
using Orion.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Northwind.Business.ValidationRules.FluentValidation
{
    class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(20);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 25);
            //RuleFor(p => p.ProductName).Must(StartWithSmt);
        }

        private bool StartWithSmt(string arg)
        {
            return arg.StartsWith("SOMETHING");
        }
    }
}
