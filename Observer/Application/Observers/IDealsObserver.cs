namespace Observer.Application.Observers;

public interface IDealsObserver {
    void Update(IDealsSubject subject);
}