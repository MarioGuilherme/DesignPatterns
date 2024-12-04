using AbstractFactory.Core.Enums;
using AbstractFactory.Infrastructure.Deliveries;
using AbstractFactory.Infrastructure.Payments;

namespace AbstractFactory.Infrastructure;

public class InternationalOrderAbstractFactory(
    CreditCardService creditCardService,
    InternationalDeliveryService internationalDeliveryService
) : IOrderAbstractFactory {
    public readonly IPaymentService _paymentService = creditCardService;
    public readonly IDeliveryService _deliveryService = internationalDeliveryService;

    public IDeliveryService GetDeliveryService() {
        return _deliveryService;
    }

    public IPaymentService GetPaymentService(PaymentMethod method) {
        return _paymentService;
    }
}