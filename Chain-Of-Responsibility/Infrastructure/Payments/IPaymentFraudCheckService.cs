using ChainOfResponsibility.Application.Models;

namespace ChainOfResponsibility.Infrastructure.Payments;

public interface IPaymentFraudCheckService {
    bool IsFraud(OrderInputModel model);
}

public class PaymentFraudCheckService : IPaymentFraudCheckService {
    public bool IsFraud(OrderInputModel model) {
        return false;
    }
}