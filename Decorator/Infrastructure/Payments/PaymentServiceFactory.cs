using Decorator.Core.Enums;
using Decorator.Infrastructure.Integrations;
using Decorator.Infrastructure.Payments.Decorators;

namespace Decorator.Infrastructure.Payments;

public class PaymentServiceFactory(
    CreditCardService creditCardService,
    PaymentSlipService paymentSlipService,
    ICoreCrmIntegrationService crmService
) : IPaymentServiceFactory {
    private readonly CreditCardService _creditCardService = creditCardService;
    private readonly PaymentSlipService _paymentSlipService = paymentSlipService;
    private readonly ICoreCrmIntegrationService _crmService = crmService;

    public IPaymentService GetService(PaymentMethod paymentMethod) {
        IPaymentService paymentService = paymentMethod switch {
            PaymentMethod.CreditCard => _creditCardService,
            PaymentMethod.PaymentSlip => _paymentSlipService,
            _ => throw new InvalidOperationException(),
        };
        return new PaymentServiceDecorator(paymentService, _crmService);
    }
}