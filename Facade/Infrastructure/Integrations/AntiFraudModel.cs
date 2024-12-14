namespace Facade.Infrastructure.Integrations;

public class AntiFraudModel(string document, decimal totalAmount) {
    public string Document { get; set; } = document;
    public decimal TotalAmount { get; set; } = totalAmount;
}