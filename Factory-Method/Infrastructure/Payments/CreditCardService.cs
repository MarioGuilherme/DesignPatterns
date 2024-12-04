using FactoryMethod.Application.Models;

namespace FactoryMethod.Infrastructure.Payments;

public class CreditCardService : IPaymentService {
    public object Process(OrderInputModel model) => "Transação aprovada";
}