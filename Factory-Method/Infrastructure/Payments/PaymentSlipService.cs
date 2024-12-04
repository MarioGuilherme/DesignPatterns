using FactoryMethod.Application.Models;

namespace FactoryMethod.Infrastructure.Payments;

public class PaymentSlipService : IPaymentService {
    public object Process(OrderInputModel model) => "Dados do Boleto";
}