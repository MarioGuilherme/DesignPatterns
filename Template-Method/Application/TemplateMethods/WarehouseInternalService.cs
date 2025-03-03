using TemplateMethod.Application.Models;

namespace TemplateMethod.Application.TemplateMethods;

public class WarehouseInternalService(OrderInputModel model) : WarehouseTemplateMethod(model) {
    protected override void Notify() {
        Console.WriteLine("Publish message to messaging bus topic.");
    }

    protected override void SeparateStockQuantities() {
        Console.WriteLine("Separating internal stock quantities.");
    }
}