using ChainOfResponsibility.Application.Models;
using ChainOfResponsibility.Infrastructure.Payments;

namespace ChainOfResponsibility.Application.ChainOfResponsibility;

public class CheckForFraudHandler(IPaymentFraudCheckService paymentFraudCheckService) : OrderHandlerBase, IOrderHandler {
    private readonly IPaymentFraudCheckService _paymentFraudCheckService = paymentFraudCheckService;

    public override bool Handle(OrderInputModel model) {
        Console.WriteLine($"Invoking CheckForFraudHandler.Handle");

        bool isFraud = _paymentFraudCheckService.IsFraud(model);

        if (isFraud)
            return false;

        return base.Handle(model);
    }
}