using Memento.Application.Models;

namespace Memento.Application.Mementos;

public class ShoppingCartOriginator(Guid customerId, List<OrderItemInputModel> items) : IShoppingCartOriginator {
    public Guid CustomerId { get; private set; } = customerId;
    public List<KeyValuePair<Guid, int>> Items { get; private set; } = items.Select(i => new KeyValuePair<Guid, int>(i.ProductId, i.Quantity)).ToList();

    public void Restore(IShoppingCartMemento shoppingCartMemento) {
        ShoppingCartMemento? concreteMemento = shoppingCartMemento as ShoppingCartMemento;
        this.Items = concreteMemento?.Items ?? [];
    }

    public IShoppingCartMemento SaveSnapshot() => new ShoppingCartMemento(this.CustomerId, this.Items);

    public void UpdateCart(List<OrderItemInputModel> items) => this.Items = items.Select(i => new KeyValuePair<Guid, int>(i.ProductId, i.Quantity)).ToList();
}