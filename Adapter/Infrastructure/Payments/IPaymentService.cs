using Adapter.Application.Models;

namespace Adapter.Infrastructure.Payments;

public interface IPaymentService {
    object Process(OrderInputModel model);
}