using ChainOfResponsibility.Application.ChainOfResponsibility;
using ChainOfResponsibility.Application.Models;
using ChainOfResponsibility.Core.Entities;
using ChainOfResponsibility.Infrastructure;
using ChainOfResponsibility.Infrastructure.Payments;
using ChainOfResponsibility.Infrastructure.Products;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibility.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase {
    [HttpPost("not-using-chain")]
    public IActionResult Post(
        OrderInputModel model,
        [FromServices] IProductRepository productRepository,
        [FromServices] IPaymentFraudCheckService fraudCheckService,
        [FromServices] ICustomerRepository customerRepository
    ) {
        Dictionary<Guid, int> itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
        bool hasStock = productRepository.HasStock(itemsDictionary);

        if (!hasStock)
            return this.BadRequest();

        Customer customer = customerRepository.GetCustomerById(model.Customer.Id);
        bool customerAllowedToBuy = customer.IsAllowedToBuy();

        if (!customerAllowedToBuy)
            return this.BadRequest();

        bool isFraud = fraudCheckService.IsFraud(model);

        if (isFraud)
            return this.BadRequest();

        return this.NoContent();
    }

    [HttpPost("using-chain")]
    public IActionResult PostWithChain(
        OrderInputModel model,
        [FromServices] IProductRepository productRepository,
        [FromServices] IPaymentFraudCheckService fraudCheckService,
        [FromServices] ICustomerRepository customerRepository
    ) {
        ValidateCustomerHandler validateCustomerHandler = new(customerRepository);
        ValidateStockHandler validateStockHandler = new(productRepository);
        CheckForFraudHandler checkForFraudHandler = new(fraudCheckService);

        validateCustomerHandler
            .SetNext(validateStockHandler)
            .SetNext(checkForFraudHandler);

        bool success = validateCustomerHandler.Handle(model);

        if (!success)
            return this.BadRequest();

        return this.NoContent();
    }
}