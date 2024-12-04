using FactoryMethod.Core.Enums;

namespace FactoryMethod.Infrastructure.Payments;

public interface IPaymentServiceFactory {
    IPaymentService GetService(PaymentMethod paymentMethod);
}