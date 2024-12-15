using Composite.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Composite.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase {
    [HttpGet("get-expenses")]
    public IActionResult GetExpenses() {
        ManagerComposite composite = new("Mário", "Diretor", 100000);

        composite.Add(new Employee("Funcionário 1", "Analista", 300));
        composite.Add(new Employee("Funcionário 2", "Analista", 300));

        ManagerComposite composite2 = new("Mário Gerente", "Gerente", 15000);

        composite.Add(composite2);

        composite2.Add(new Employee("Funcionário 3", "Analista", 300));
        composite2.Add(new Employee("Funcionário 4", "Analista", 300));

        return this.Ok(new {
            expensesDirector = composite.GetExpenses(),
            expensesManager = composite2.GetExpenses()
        });
    }
}
