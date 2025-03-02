using Strategy.Core.Enums;

namespace Strategy.Infrastructure.Payments.Strategies;

public class PaymentStrategyFactory : IPaymentStrategyFactory {
    public IPaymentStrategy GetStrategy(PaymentMethod paymentMethod) {
        IPaymentStrategy strategy;

        if (paymentMethod is PaymentMethod.PaymentSlip)
            strategy = new PaymentSlipStrategy();
        else {
            strategy = new CreditCardStrategy();
        }

        return strategy;
    }
}