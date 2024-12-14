using Facade.Application.Models;

namespace Facade.Infrastructure.Payments;

public class CreditCardService : IPaymentService {
    public object Process(OrderInputModel model) {
        return "Transação aprovada";
    }
}