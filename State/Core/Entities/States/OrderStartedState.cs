namespace State.Core.Entities.States;

public class OrderStartedState(List<Guid> items) : OrderStateBase(items), IOrderState {
    public void Add(Guid item) {
        Items.Add(item);

        Console.WriteLine("Order updated.");
    }

    public void Handle() {
        Console.WriteLine("Order moving from Started to next state.");

        Context.SetCurrentState(new OrderPreparingState(Items));
    }
}
