namespace Adapter.Infrastructure.Payments.Models;

public class PaymentSlipModel {
    public PaymentSlipModel() { }

    public PaymentSlipModel(string barCode, string ourNumber, DateTime expiresAt, DateTime processedAt,
    decimal documentAmount, Payer payer, Receiver receiver) {
        this.BarCode = barCode;
        this.OurNumber = ourNumber;
        this.ExpiresAt = expiresAt;
        this.ProcessedAt = processedAt;
        this.DocumentAmount = documentAmount;
        this.Payer = payer;
        this.Receiver = receiver;
    }

    public string BarCode { get; set; }
    public string OurNumber { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime ProcessedAt { get; set; }
    public decimal DocumentAmount { get; set; }
    public Payer Payer { get; set; }
    public Receiver Receiver { get; set; }
}

public class Payer(string fullName, string document, string fullAddress) {
    public string FullName { get; set; } = fullName;
    public string Document { get; set; } = document;
    public string FullAddress { get; set; } = fullAddress;
}

public class Receiver(string fullName, string document, string fullAddress) {
    public string FullName { get; set; } = fullName;
    public string Document { get; set; } = document;
    public string FullAddress { get; set; } = fullAddress;
}