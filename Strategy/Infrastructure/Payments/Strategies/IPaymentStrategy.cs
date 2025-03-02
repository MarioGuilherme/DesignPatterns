using Strategy.Application.Models;

namespace Strategy.Infrastructure.Payments.Strategies;

public interface IPaymentStrategy {
    object Process(OrderInputModel model);
}
