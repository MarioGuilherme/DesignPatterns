namespace Flyweight.Application.Models;

public class PaymentMethodViewModel(string guidanceText, decimal? minimumValue, decimal? maximumValue) {
    public string GuidanceText { get; private set; } = guidanceText;
    public decimal? MinimumValue { get; private set; } = minimumValue;
    public decimal? MaximumValue { get; private set; } = maximumValue;
}
