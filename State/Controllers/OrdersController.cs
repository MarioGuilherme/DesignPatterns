using Microsoft.AspNetCore.Mvc;
using State.Application.Models;
using State.Core.Entities.States;

namespace State.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase {
    [HttpPost("state")]
    public IActionResult OrderState(OrderInputModel model) {
        List<Guid> items = model.Items.Select(i => i.ProductId).ToList();

        OrderStateContext context = new(new OrderStartedState(items));

        context.Handle();

        context.Add(Guid.NewGuid());

        context.Handle();
        context.Handle();
        context.Handle();

        return this.NoContent();
    }
}