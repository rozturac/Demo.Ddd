using FluentValidation;
using Demo.Ddd.Application.Baskets.AddItemCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Application.Baskets.AddItem
{
    public class AddItemToBasketCommandValidator : AbstractValidator<AddItemToBasketCommand>
    {
        public AddItemToBasketCommandValidator()
        {
            RuleFor(p => p.ProductCode).NotEmpty();
            RuleFor(p => p.Quantity).GreaterThan(0);
        }
    }
}
