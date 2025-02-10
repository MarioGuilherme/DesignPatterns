namespace Observer.Application.Observers;

public class DealsSubject : IDealsSubject {
    private readonly ICollection<IDealsObserver> _observers = [];
    public ICollection<string> CurrentDeals { get; private set; } = [];

    public void Attach(IDealsObserver observer) {
        if (!this._observers.Any(o => o.Equals(observer)))
            this._observers.Add(observer);
    }

    public void Detach(IDealsObserver observer) => this._observers.Remove(observer);

    public void Notify() {
        foreach (IDealsObserver observer in this._observers) observer.Update(this);
    }

    public void SetDeals(ICollection<string> deals) {
        this.CurrentDeals = deals;
        this.Notify();
    }
}
