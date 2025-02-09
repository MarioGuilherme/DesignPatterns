namespace Memento.Application.Mementos;

public interface IShoppingCartMemento {
    Guid CustomerId { get; }
    List<KeyValuePair<Guid, int>> Items { get; }
    DateTime SavedAt { get; }
}
