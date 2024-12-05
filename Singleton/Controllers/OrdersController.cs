using Singleton.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Singleton.Application.Configurations;

namespace Singleton.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase {
    [HttpPost]
    public IActionResult Post(OrderInputModel model) {
        return this.Ok(BusinessHours.GetInstance());
    }
}