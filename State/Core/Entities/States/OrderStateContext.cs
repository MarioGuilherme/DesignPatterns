namespace State.Core.Entities.States;

public class OrderStateContext {

    private IOrderState _state;

    public OrderStateContext(IOrderState state) {
        this.SetCurrentState(state);
    }

    public void SetCurrentState(IOrderState state) {
        _state = state;
        _state.SetContext(this);
    }

    public void Handle() {
        _state.Handle();
    }

    public void Add(Guid item) {
        _state.Add(item);
    }
}
