using Microsoft.AspNetCore.Mvc;
using Observer.Application.Observers;

namespace Observer.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase {
    [HttpGet("deals")]
    public IActionResult Deals(
        [FromServices] IEnumerable<IDealsObserver> observers,
        [FromServices] IDealsSubject subject
    ) {
        foreach (IDealsObserver observer in observers) subject.Attach(observer); // Isso pode ser feita na inicialização da aplicação

        subject.SetDeals(["Xbox SX - R$4500", "PS5 - R$4400"]);

        return this.NoContent();
    }
}