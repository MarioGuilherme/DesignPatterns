namespace Facade.Infrastructure.Payments.Models;

public class PaymentSlipModel {
    public PaymentSlipModel() {

    }

    public PaymentSlipModel(string barCode, string ourNumber, DateTime expiresAt, DateTime processedAt,
    decimal documentAmount, Payer payer, Receiver receiver) {
        BarCode = barCode;
        OurNumber = ourNumber;
        ExpiresAt = expiresAt;
        ProcessedAt = processedAt;
        DocumentAmount = documentAmount;
        Payer = payer;
        Receiver = receiver;
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