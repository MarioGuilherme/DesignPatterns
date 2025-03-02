using Microsoft.AspNetCore.Mvc;
using Strategy.Application.Models;
using Strategy.Infrastructure.Payments.Strategies;

namespace Strategy.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase {
    [HttpPost("payment-using-strategy")]
    public IActionResult ProcessPaymentWithStrategy(OrderInputModel model, [FromServices] IPaymentContext context, [FromServices] IPaymentStrategyFactory factory) {
        IPaymentStrategy strategy = factory.GetStrategy(model.PaymentInfo.PaymentMethod);

        object result = context
            .SetStrategy(strategy)
            .Process(model);

        return this.Ok(result);
    }
}