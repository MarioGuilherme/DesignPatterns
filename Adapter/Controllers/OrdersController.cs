using Adapter.Application.Models;
using Adapter.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController(IPaymentService paymentService) : ControllerBase {
    private readonly IPaymentService _paymentService = paymentService;

    [HttpPost]
    public IActionResult Post(OrderInputModel model) {
        this._paymentService.Process(model);

        return this.NoContent();
    }
}