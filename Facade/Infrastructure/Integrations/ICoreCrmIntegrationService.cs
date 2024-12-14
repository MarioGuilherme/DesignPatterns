using Facade.Application.Models;

namespace Facade.Infrastructure.Integrations;

public interface ICoreCrmIntegrationService {
    void Sync(OrderInputModel model);
}