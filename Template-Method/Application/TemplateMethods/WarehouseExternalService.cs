using TemplateMethod.Application.Models;

namespace TemplateMethod.Application.TemplateMethods;

public class WarehouseExternalService(OrderInputModel model) : WarehouseTemplateMethod(model) {
    protected override void Notify() {
        Console.WriteLine("Notifying other components through REST APIs");
    }

    protected override void SeparateStockQuantities() {
        Console.WriteLine("Separating external stock quantities.");
    }
}