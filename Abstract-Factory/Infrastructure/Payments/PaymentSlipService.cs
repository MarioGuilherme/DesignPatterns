using AbstractFactory.Application.Models;

namespace AbstractFactory.Infrastructure.Payments;

public class PaymentSlipService : IPaymentService {
    public object Process(OrderInputModel model) {
        return "Dados do Boleto";
    }
}