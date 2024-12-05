using Adapter.Infrastructure.Payments.Models;
using Adapter.Application.Models;

namespace Adapter.Infrastructure.Payments;

public interface IExternalPaymentSlipService {
    // Pode adaptar o que retorna de um servi�o de terceiro (ExternalPaymentSlipModel) quanto o que vai ser enviado (OrderInputModel)
    // Mas no exemplo s� fazemos que o que retorna (ExternalPaymentSlipModel), mas podemos usar esse pattern para o que ser� enviado
    ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model);
}