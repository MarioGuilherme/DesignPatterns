using Decorator.Application.Models;
using Decorator.Infrastructure.Payments.Models;
using Decorator.Infrastructure.Payments.Adapters;

namespace Decorator.Infrastructure.Payments;

public class PaymentSlipService(IExternalPaymentSlipService externalService) : IPaymentService {
    private readonly IExternalPaymentSlipService _externalService = externalService;

    public object Process(OrderInputModel model) {
        PaymentSlipServiceAdapter adapter = new(this._externalService);

        PaymentSlipModel paymentSlipModel = adapter.GeneratePaymentSlip(model);

        return "Dados do Boleto";
    }
}