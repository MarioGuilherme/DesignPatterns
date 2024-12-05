using Adapter.Application.Models;
using Adapter.Infrastructure.Payments.Adapters;
using Adapter.Infrastructure.Payments.Models;

namespace Adapter.Infrastructure.Payments;

public class PaymentSlipService(IExternalPaymentSlipService externalService) : IPaymentService {
    private readonly IExternalPaymentSlipService _externalService = externalService;

    public object Process(OrderInputModel model) {
        PaymentSlipServiceAdapter paymentSlipServiceAdapter = new(this._externalService);

        PaymentSlipModel paymentSlipModel = paymentSlipServiceAdapter.GeneratePaymentSlip(model);

        return "Dados do Boleto";
    }
}