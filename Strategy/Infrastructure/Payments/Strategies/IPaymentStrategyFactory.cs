using Strategy.Core.Enums;

namespace Strategy.Infrastructure.Payments.Strategies;

public interface IPaymentStrategyFactory {
    IPaymentStrategy GetStrategy(PaymentMethod paymentMethod);
}