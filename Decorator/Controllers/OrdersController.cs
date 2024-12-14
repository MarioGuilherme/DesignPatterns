using Decorator.Application.Models;
using Decorator.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Decorator.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController(IPaymentServiceFactory paymentServiceFactory) : ControllerBase {
    private readonly IPaymentServiceFactory _paymentServiceFactory = paymentServiceFactory;

    [HttpPost("simpler")]
    public IActionResult SimplerPost(
        [FromServices] IPaymentServiceFactory paymentServiceFactory,
        // Ou sem DI //[FromServices] ExternalPaymentSlipService externalPaymentSlipService,
        OrderInputModel model
    ) {
        IPaymentService paymentService = paymentServiceFactory.GetService(model.PaymentInfo.PaymentMethod);

        // Ou sem DI
        //ExternalPaymentSlipServiceDecorator paymentSlipServiceDecorator = new(externalPaymentSlipService);

        object paymentResult = paymentService.Process(model);

        return this.NoContent();
    }
}