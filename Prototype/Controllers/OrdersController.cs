using Prototype.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Prototype.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase {
    [HttpPost]
    public IActionResult Post(OrderInputModel model) {
        string customerData = model.Customer.ReturnDataAsString();

        object customerCopy = model.Customer.Clone();
        string customerCopyData = (customerCopy as CustomerInputModel).ReturnDataAsString();

        return Ok(new { customerData, customerCopyData });
    }
}