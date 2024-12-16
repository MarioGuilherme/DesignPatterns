using Flyweight.Core.Enums;
using Flyweight.Application;
using Flyweight.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flyweight.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase {
    [HttpGet("payment-methods-old/{paymentMethod}")]
    public IActionResult GetPaymentMethodDetailsOld(PaymentMethod? paymentMethod) {
        PaymentMethodViewModel model;

        if (paymentMethod == PaymentMethod.CreditCard)
            model = new PaymentMethodViewModel("Sobre o Cartão de Crédito.", 1, null);
        else if (paymentMethod == PaymentMethod.PaymentSlip)
            model = new PaymentMethodViewModel("Sobre o Boleto.", 10, 1000);
        else if (paymentMethod == PaymentMethod.PayPal)
            model = new PaymentMethodViewModel("Sobre o PayPal.", 16.5m, null);
        else
            return this.BadRequest("Não foi passada uma forma de pagamento válida.");

        return this.Ok(model);
    }

    [HttpGet("payment-methods/{paymentMethod}")]
    public IActionResult GetPaymentMethodDetails(PaymentMethod paymentMethod, [FromServices] PaymentMethodsFactory factory) {
        if (paymentMethod == PaymentMethod.Unknown) return this.BadRequest();

        PaymentMethodViewModel model = factory.GetPaymentMethod(paymentMethod);

        return this.Ok(model);
    }
}
