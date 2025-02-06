using Iterator.Application.Models;
using Iterator.Core.Entities;
using Iterator.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Iterator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase {
    [HttpGet("report-notify-blocked-customers")]
    public IActionResult NotifyBlockedCustomerEmail([FromServices] ICustomerRepository repository) {
        List<Customer> blockedCustomers = repository.GetBlockedCustomers();

        CustomersToNotifyQueryModelIterator iterator = new(blockedCustomers, "Mário");

        foreach (KeyValuePair<string, string> customer in iterator)
            Console.WriteLine($"Customer: {customer.Key}, Email: {customer.Value}");

        Console.WriteLine($"Utilizando acesso direto: {iterator["Mário 1"]}");

        return this.Ok();
    }
}
