using Builder.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Builder.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController(IPaymentService paymentService) : ControllerBase {
    private readonly IPaymentService _paymentService = paymentService;

    [HttpPost]
    public IActionResult Post() {
        this._paymentService.Process();

        return this.NoContent();
    }
}