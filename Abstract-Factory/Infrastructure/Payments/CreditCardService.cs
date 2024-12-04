using AbstractFactory.Application.Models;

namespace AbstractFactory.Infrastructure.Payments;

public class CreditCardService : IPaymentService {
    public object Process(OrderInputModel model) {
        return "Transação aprovada";
    }
}