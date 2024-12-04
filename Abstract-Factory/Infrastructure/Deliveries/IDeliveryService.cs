using AbstractFactory.Application.Models;

namespace AbstractFactory.Infrastructure.Deliveries;

public interface IDeliveryService {
    void Deliver(OrderInputModel model);
}