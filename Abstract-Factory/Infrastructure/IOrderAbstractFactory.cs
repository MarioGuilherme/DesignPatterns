using AbstractFactory.Core.Enums;
using AbstractFactory.Infrastructure.Deliveries;
using AbstractFactory.Infrastructure.Payments;

namespace AbstractFactory.Infrastructure;

public interface IOrderAbstractFactory {
    IPaymentService GetPaymentService(PaymentMethod method);
    IDeliveryService GetDeliveryService();
}