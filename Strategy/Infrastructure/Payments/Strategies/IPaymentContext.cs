using Strategy.Application.Models;

namespace Strategy.Infrastructure.Payments.Strategies;

public interface IPaymentContext {
    object Process(OrderInputModel model);
    IPaymentContext SetStrategy(IPaymentStrategy strategy);
}