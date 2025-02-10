namespace Observer.Application.Observers;

public interface IDealsSubject {
    ICollection<string> CurrentDeals { get; } // Atributo mais específico do negócio
    void SetDeals(ICollection<string> deals); // Método mais específico do negócio
    void Attach(IDealsObserver observer);
    void Detach(IDealsObserver observer);
    void Notify();
}