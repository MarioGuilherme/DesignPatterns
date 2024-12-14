using Proxy.Infrastructure.Proxies;
using Microsoft.AspNetCore.Mvc;
using Proxy.Core.Entities;

namespace Proxy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase {
    [HttpGet("get-blocked-customers")]
    public IActionResult GetBlockedCustomers([FromServices] CustomerRepositoryProxy proxy) {
        List<Customer>? blockedCustomers = proxy.GetBlockedCustomers();

        if (blockedCustomers is null) return this.Unauthorized();

        return this.Ok(blockedCustomers);
    }
}
