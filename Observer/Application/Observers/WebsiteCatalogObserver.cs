namespace Observer.Application.Observers;

public class WebsiteCatalogObserver : IDealsObserver {
    public void Update(IDealsSubject subject)
        => Console.WriteLine($"Updating website catalog design. Total deals: {subject.CurrentDeals.Count}");
}