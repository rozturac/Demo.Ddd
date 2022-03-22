using Demo.Ddd.Application.Baskets.AddItem;
using Demo.Ddd.Application.Common;
using Demo.Ddd.Application.Common.Command;
using Demo.Ddd.Application.Common.Data;
using Demo.Ddd.Application.Common.Exceptions;
using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.Customers.Baskets;
using Demo.Ddd.Domain.Products;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Ddd.Application.Baskets.AddItemCommand
{
    public class AddItemToBasketCommand : BaseCommand<AddItemToBasketResultDto>
    {
        public Guid? CustomerId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }

    public class AddItemToBasketCommandHandler : IBaseCommandHandler<AddItemToBasketCommand, AddItemToBasketResultDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBasketCounter _basketCounter;

        public AddItemToBasketCommandHandler(IUnitOfWork uow, IBasketCounter basketCounter)
        {
            _uow = uow;
            _basketCounter = basketCounter;
        }

        public async Task<GenericResult<AddItemToBasketResultDto>> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            var product = await _uow.ProductRepository.GetProductByCode(request.ProductCode);


            if (product == null)
                throw new NotFoundException(nameof(Product), request.ProductCode);

            var customer = request.CustomerId.HasValue
                ? await _uow.CustomerRepository.GetByIdAsync(request.CustomerId.Value)
                : Customer.CreateGuest();

            customer.Basket.AddProduct(product.GetProductPriceData(), request.Quantity, _basketCounter);

            if (!request.CustomerId.HasValue)
                await _uow.CustomerRepository.AddAsync(customer);

            return GenericResult<AddItemToBasketResultDto>.Success(new AddItemToBasketResultDto
            {
                CustomerId = customer.Id,
                Value = customer.Basket.Value,
            });
        }
    }
}
