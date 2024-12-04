using AbstractFactory.Core.Enums;
using AbstractFactory.Infrastructure.Deliveries;
using AbstractFactory.Infrastructure.Payments;

namespace AbstractFactory.Infrastructure;

public class NationalOrderAbstractFactory(NationalDeliveryService nationalDeliveryService, IPaymentServiceFactory paymentServiceFactory) : IOrderAbstractFactory {
    private readonly NationalDeliveryService _nationalDeliveryService = nationalDeliveryService;
    private readonly IPaymentServiceFactory _paymentServiceFactory = paymentServiceFactory;

    public IDeliveryService GetDeliveryService() {
        return _nationalDeliveryService;
    }

    public IPaymentService GetPaymentService(PaymentMethod method) {
        return _paymentServiceFactory.GetService(method);
    }
}