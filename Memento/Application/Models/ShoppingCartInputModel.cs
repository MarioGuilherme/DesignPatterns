namespace Memento.Application.Models;

public class ShoppingCartInputModel {
    public Guid CustomerId { get; set; }
    public List<OrderItemInputModel> Items { get; set; }
}