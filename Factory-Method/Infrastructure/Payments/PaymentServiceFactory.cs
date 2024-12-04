using FactoryMethod.Core.Enums;

namespace FactoryMethod.Infrastructure.Payments;

public class PaymentServiceFactory(CreditCardService creditCardService, PaymentSlipService paymentSlipService) : IPaymentServiceFactory {
    private readonly CreditCardService _creditCardService = creditCardService;
    private readonly PaymentSlipService _paymentSlipService = paymentSlipService;

    public IPaymentService GetService(PaymentMethod paymentMethod) {
        IPaymentService paymentService = paymentMethod switch {
            PaymentMethod.CreditCard => _creditCardService,
            PaymentMethod.PaymentSlip => _paymentSlipService,
            _ => throw new InvalidOperationException(),
        };
        return paymentService;
    }
}