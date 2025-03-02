namespace State.Core.Entities.States;

internal class OrderOnWayToDeliverState(List<Guid> items) : OrderStateBase(items), IOrderState {
    public void Add(Guid item) {
        throw new InvalidOperationException("Invalid operation.");
    }

    public void Handle() {
        Console.WriteLine("Order moving from On Way To Deliver to next state.");

        Context.SetCurrentState(new OrderCompletedState(Items));
    }
}