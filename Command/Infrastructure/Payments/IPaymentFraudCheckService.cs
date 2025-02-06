using Command.Application.Models;

namespace Command.Infrastructure.Payments;

public interface IPaymentFraudCheckService {
    bool IsFraud(OrderInputModel model);
    bool IsFraudV2(decimal totalAmount, Guid customerId, string customerName, string document);
    bool IsFraudV2UsingCommand(FraudCheckModel command);
}
