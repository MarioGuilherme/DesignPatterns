using TemplateMethod.Application.Models;

namespace TemplateMethod.Application.TemplateMethods;

public abstract class WarehouseTemplateMethod(OrderInputModel model) {
    private Dictionary<Guid, int> _orderItems = [];
    protected OrderInputModel _model;

    public void ProccessOrder() {
        // O método padrão define o esqueleto de um algoritmo.
        this.ExtractOrderData();
        this.SeparateStockQuantities();
        this.Notify();

    }

    protected void ExtractOrderData() { // Comum entre as implementações
        foreach (OrderItemInputModel item in _model.Items) {
            _orderItems.Add(item.ProductId, item.Quantity);
        }
    }

    protected abstract void SeparateStockQuantities();

    protected abstract void Notify();
}
