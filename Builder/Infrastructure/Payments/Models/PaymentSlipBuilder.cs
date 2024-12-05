namespace Builder.Infrastructure.Payments.Models;

public class PaymentSlipBuilder {
    private PaymentSlipModel _paymentSlipModel;

    public PaymentSlipBuilder() {
    }

    public PaymentSlipBuilder Start() {
        this._paymentSlipModel = new PaymentSlipModel();

        return this;
    }

    public PaymentSlipBuilder WithReceiver(Receiver receiver) {
        this._paymentSlipModel.Receiver = receiver;

        return this;
    }

    // Maior granularidade (especifico por parâmetro)
    public PaymentSlipBuilder WithPayer(Payer payer) {
        this._paymentSlipModel.Payer = payer;

        return this;
    }

    // Menos granularidade (para muitos parâmetros)
    public PaymentSlipBuilder WithPaymentDocument(string barCode, string ourNumber, decimal documentAmount) {
        this._paymentSlipModel.BarCode = barCode;
        this._paymentSlipModel.OurNumber = ourNumber;
        this._paymentSlipModel.DocumentAmount = documentAmount;

        return this;
    }

    public PaymentSlipBuilder WithDates(DateTime processedAt, DateTime expiresAt) {
        this._paymentSlipModel.ProcessedAt = processedAt;
        this._paymentSlipModel.ExpiresAt = expiresAt;

        return this;
    }

    public PaymentSlipModel Build() {
        return this._paymentSlipModel;
    }
}