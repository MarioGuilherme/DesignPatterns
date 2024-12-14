using Facade.Application.Models;
using Facade.Infrastructure.Integrations;

namespace Facade.Infrastructure.Payments.Decorators;

public class PaymentServiceDecorator(
    IPaymentService paymentService,
    ICoreCrmIntegrationService crmService,
    IAntiFraudFacade antiFraudFacade
) : IPaymentService {
    private readonly IPaymentService _paymentService = paymentService;
    private readonly ICoreCrmIntegrationService _crmService = crmService;
    private readonly IAntiFraudFacade _antiFraudFacade = antiFraudFacade;

    public object Process(OrderInputModel model) {
        // Toda a lógica da chamada HTTP foi delegada à classe, tirando toda a lógica daqui
        // Isso pode ocorrer também sem ser HTTP, e sim com um inteiro subsistema de objetos
        AntiFraudModel antiFraudModel = new(model.Customer.Document, model.TotalPrice);
        AntiFraudResultModel? antiFraudResult = this._antiFraudFacade.Check(antiFraudModel);

        if (antiFraudResult is null || antiFraudResult.CheckResult)
            throw new InvalidOperationException(antiFraudResult?.Comments);

        object result = this._paymentService.Process(model);

        this._crmService.Sync(model);

        return result;
    }
}