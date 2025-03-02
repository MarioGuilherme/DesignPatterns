namespace State.Core.Entities.States;

public class OrderCompletedState(List<Guid> items) : OrderStateBase(items), IOrderState {
    public void Add(Guid item) {
        throw new InvalidOperationException("Invalid operation.");
    }

    public void Handle() {
        Console.WriteLine("No more states.");
    }
}