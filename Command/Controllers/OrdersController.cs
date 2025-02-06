using Command.Application.Models;
using Command.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Command.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase {
    [HttpPost("not-using-command")]
    public IActionResult NotPostUsingCommand(OrderInputModel model, [FromServices] IPaymentFraudCheckService fraudCheckService) {
        decimal total = model.Items.Sum(i => i.Price * i.Quantity);

        bool isFraud = fraudCheckService.IsFraudV2(total, model.Customer.Id, model.Customer.FullName, model.Customer.Document);

        if (isFraud)
            return this.BadRequest();

        var message = new {
            total,
            customerId = model.Customer.Id,
            fullName = model.Customer.FullName,
            document = model.Customer.Document
        };

        // Chamar um serviço de mensageria para enviar esse objeto como JSON
        // Guardar um log desse objeto

        return this.NoContent();
    }

    [HttpPost("using-command")]
    public IActionResult PostUsingCommand(OrderInputModel model, [FromServices] IPaymentFraudCheckService fraudCheckService) {
        decimal total = model.Items.Sum(i => i.Price * i.Quantity);
        FraudCheckModel command = new(total, model.Customer.Id, model.Customer.FullName, model.Customer.Document);

        bool isFraud = fraudCheckService.IsFraudV2UsingCommand(command);

        if (isFraud)
            return this.BadRequest();

        // Chamar um serviço de mensageria para enviar esse objeto como JSON
        // Guardar um log desse objeto

        return this.NoContent();
    }
}