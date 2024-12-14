using Facade.Application.Models;

namespace Facade.Infrastructure.Payments;

public interface IPaymentService {
    object Process(OrderInputModel model);
}