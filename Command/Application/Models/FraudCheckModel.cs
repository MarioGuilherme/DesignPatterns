namespace Command.Application.Models;

public class FraudCheckModel(decimal totalAmount, Guid customerId, string customerName, string customerDocument) {
    public decimal TotalAmount { get; private set; } = totalAmount;
    public Guid CustomerId { get; private set; } = customerId;
    public string CustomerName { get; private set; } = customerName;
    public string CustomerDocument { get; private set; } = customerDocument;
}