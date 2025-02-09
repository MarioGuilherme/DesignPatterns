namespace Memento.Application.Mementos;

public class ShoppingCartCaretaker(ShoppingCartOriginator originator) {
    public readonly ShoppingCartOriginator Originator = originator;
    private readonly Stack<IShoppingCartMemento> _mementos = [];

    public void Backup() => this._mementos.Push(Originator.SaveSnapshot());

    public void Undo() {
        if (!this._mementos.TryPop(out IShoppingCartMemento? lastMemento)) return;
        Originator.Restore(lastMemento);
    }

    public void PrintHistory() {
        foreach (IShoppingCartMemento memento in this._mementos) {
            string items = string.Join(' ', memento.Items.Select(i => $"> Item: {i.Key}, Quantity: {i.Value}"));

            Console.WriteLine($"Customer: {memento.CustomerId}, Items: {items}, Saved At: {memento.SavedAt}\n");
        }
    }
}