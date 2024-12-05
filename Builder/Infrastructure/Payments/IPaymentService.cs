using Builder.Application.Models;

namespace Builder.Infrastructure.Payments;

public interface IPaymentService {
    object Process();
}