using Strategy.Application.Models;

namespace Strategy.Infrastructure.Payments.Strategies;

public class CreditCardStrategy : IPaymentStrategy {
    public object Process(OrderInputModel model) {
        return "Transação aprovada.";
    }
}