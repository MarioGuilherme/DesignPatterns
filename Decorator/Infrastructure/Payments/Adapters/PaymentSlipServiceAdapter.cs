using Decorator.Infrastructure.Payments.Models;
using Decorator.Application.Models;

namespace Decorator.Infrastructure.Payments.Adapters;

public class PaymentSlipServiceAdapter(IExternalPaymentSlipService externalService) {
    private readonly IExternalPaymentSlipService _externalService = externalService;

    public PaymentSlipModel GeneratePaymentSlip(OrderInputModel model) {
        ExternalPaymentSlipModel externalModel = this._externalService.GeneratePaymentSlip(model);

        PaymentSlipBuilder builder = new();

        PaymentSlipModel paymentSlipWithBuilder = builder
            .Start()
            .WithPayer(new Payer(externalModel.payer_name, externalModel.payer_doc, externalModel.payer_addr))
            .WithReceiver(new Receiver(externalModel.receiver_name, externalModel.receiver_doc, externalModel.receiver_addr))
            .WithPaymentDocument(externalModel.bar_code, externalModel.number, externalModel.doc_amount)
            .WithDates(externalModel.proc_date, externalModel.exp_date)
            .Build();

        return paymentSlipWithBuilder;
    }
}