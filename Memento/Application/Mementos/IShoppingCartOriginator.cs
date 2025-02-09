using Memento.Application.Models;

namespace Memento.Application.Mementos;

public interface IShoppingCartOriginator {
    Guid CustomerId { get; }
    List<KeyValuePair<Guid, int>> Items { get; }

    void Restore(IShoppingCartMemento shoppingCartMemento);
    IShoppingCartMemento SaveSnapshot();
    void UpdateCart(List<OrderItemInputModel> items);
}
