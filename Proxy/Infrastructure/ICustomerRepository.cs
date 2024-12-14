using Proxy.Core.Entities;

namespace Proxy.Infrastructure;

public interface ICustomerRepository {
    List<Customer>? GetBlockedCustomers();
}
