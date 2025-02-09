namespace Memento.Application.Mementos;

public class ShoppingCartMemento(Guid customerId, List<KeyValuePair<Guid, int>> items) : IShoppingCartMemento {
    public Guid CustomerId { get; private set; } = customerId;
    public List<KeyValuePair<Guid, int>> Items { get; private set; } = items;
    public DateTime SavedAt { get; private set; } = DateTime.Now;
}