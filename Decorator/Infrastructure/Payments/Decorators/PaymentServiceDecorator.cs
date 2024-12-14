using Decorator.Application.Models;
using Decorator.Infrastructure.Integrations;

namespace Decorator.Infrastructure.Payments.Decorators;

public class PaymentServiceDecorator(IPaymentService paymentService, ICoreCrmIntegrationService crmService) : IPaymentService {
    private readonly IPaymentService _paymentService = paymentService;
    private readonly ICoreCrmIntegrationService _crmService = crmService;

    public object Process(OrderInputModel model) {
        object result = _paymentService.Process(model);

        this._crmService.Sync(model);

        return result;
    }
}