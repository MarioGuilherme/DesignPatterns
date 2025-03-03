using Microsoft.AspNetCore.Mvc;
using TemplateMethod.Application.Models;
using TemplateMethod.Application.TemplateMethods;

namespace TemplateMethod.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase {
    [HttpPost("template-method")]
    public IActionResult OrderTemplate(OrderInputModel model) {
        WarehouseTemplateMethod templateMethod;

        // Poderia usar Factory-Method
        if (model.IsExternal)
            templateMethod = new WarehouseExternalService(model);
        else
            templateMethod = new WarehouseInternalService(model);

        // O método padrão define o esqueleto de um algoritmo. (PODE FICAR NOUTRA CLASSE)
        templateMethod.ProccessOrder();

        return this.NoContent();
    }
}