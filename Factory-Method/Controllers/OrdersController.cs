using FactoryMethod.Application.Models;
using FactoryMethod.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace FactoryMethod.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController(IPaymentServiceFactory paymentServiceFactory) : ControllerBase {
    private readonly IPaymentServiceFactory _paymentServiceFactory = paymentServiceFactory;

    [HttpPost]
    public IActionResult Post(OrderInputModel model) {
        IPaymentService service = _paymentServiceFactory.GetService(model.PaymentInfo.PaymentMethod);

        service.Process(model);

        return this.NoContent();
    }
}