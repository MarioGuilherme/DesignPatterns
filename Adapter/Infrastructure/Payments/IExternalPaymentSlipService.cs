using Adapter.Infrastructure.Payments.Models;
using Adapter.Application.Models;

namespace Adapter.Infrastructure.Payments;

public interface IExternalPaymentSlipService {
    // Pode adaptar o que retorna de um serviço de terceiro (ExternalPaymentSlipModel) quanto o que vai ser enviado (OrderInputModel)
    // Mas no exemplo só fazemos que o que retorna (ExternalPaymentSlipModel), mas podemos usar esse pattern para o que será enviado
    ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model);
}