using Facade.Core.Enums;
using Facade.Infrastructure.Integrations;
using Facade.Infrastructure.Payments.Decorators;

namespace Facade.Infrastructure.Payments;

public class PaymentServiceFactory(
    CreditCardService creditCardService,
    PaymentSlipService paymentSlipService,
    ICoreCrmIntegrationService crmService,
    IAntiFraudFacade antiFraudFacade
) : IPaymentServiceFactory {
    private readonly CreditCardService _creditCardService = creditCardService;
    private readonly PaymentSlipService _paymentSlipService = paymentSlipService;
    private readonly ICoreCrmIntegrationService _crmService = crmService;
    private readonly IAntiFraudFacade _antiFraudFacade = antiFraudFacade;

    public IPaymentService GetService(PaymentMethod paymentMethod) {
        IPaymentService paymentService = paymentMethod switch {
            PaymentMethod.CreditCard => this._creditCardService,
            PaymentMethod.PaymentSlip => this._paymentSlipService,
            _ => throw new InvalidOperationException(),
        };
        return new PaymentServiceDecorator(paymentService, this._crmService, this._antiFraudFacade);
    }
}