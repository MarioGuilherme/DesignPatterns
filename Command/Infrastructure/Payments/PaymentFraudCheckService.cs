using Command.Application.Models;

namespace Command.Infrastructure.Payments;

public class PaymentFraudCheckService : IPaymentFraudCheckService {
    public bool IsFraud(OrderInputModel model) {
        return false;
    }

    public bool IsFraudV2(decimal totalAmount, Guid customerId, string customerName, string document) {
        return false;
    }

    public bool IsFraudV2UsingCommand(FraudCheckModel command) {
        return false;
    }
}
