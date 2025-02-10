namespace Observer.Application.Observers;

public class MarketingCampaignObserver : IDealsObserver {
    public void Update(IDealsSubject subject)
        => Console.WriteLine($"Sending an email to subscribed users. Total deals: {subject.CurrentDeals.Count}");
}