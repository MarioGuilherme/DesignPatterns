namespace State.Core.Entities.States;

public class OrderPreparingState(List<Guid> items) : OrderStateBase(items), IOrderState {
    public void Add(Guid item) {
        Items.Add(item);

        Console.WriteLine("Order updated.");
    }

    public void Handle() {
        Console.WriteLine("Order moving from Preparing to next state.");

        Context.SetCurrentState(new OrderOnWayToDeliverState(Items));
    }
}