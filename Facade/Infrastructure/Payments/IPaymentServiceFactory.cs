using Facade.Core.Enums;

namespace Facade.Infrastructure.Payments;

public interface IPaymentServiceFactory {
    IPaymentService GetService(PaymentMethod paymentMethod);
}