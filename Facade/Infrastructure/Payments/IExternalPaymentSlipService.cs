// Exemplo mais básico [Sem Factory Method]
using Facade.Infrastructure.Payments.Models;
using Facade.Application.Models;

namespace Facade.Infrastructure.Payments;

public interface IExternalPaymentSlipService {
    ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model);
}

public class ExternalPaymentSlipService : IExternalPaymentSlipService {
    public ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model) {
        throw new NotImplementedException();
    }
}

public class ExternalPaymentSlipServiceDecorator(IExternalPaymentSlipService externalPaymentSlipService) : IExternalPaymentSlipService {
    private readonly IExternalPaymentSlipService _externalPaymentSlipService = externalPaymentSlipService;

    public ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model) {
        Console.WriteLine("Extendendo IExternalPaymentSlipService");

        return this._externalPaymentSlipService.GeneratePaymentSlip(model);
    }
}