using Facade.Application.Models;
using Facade.Infrastructure.Payments.Models;
using Facade.Infrastructure.Payments.Adapters;

namespace Facade.Infrastructure.Payments;

public class PaymentSlipService(IExternalPaymentSlipService externalService) : IPaymentService {
    private readonly IExternalPaymentSlipService _externalService = externalService;

    public object Process(OrderInputModel model) {
        PaymentSlipServiceAdapter adapter = new(this._externalService);

        PaymentSlipModel paymentSlipModel = adapter.GeneratePaymentSlip(model);

        return "Dados do Boleto";
    }
}