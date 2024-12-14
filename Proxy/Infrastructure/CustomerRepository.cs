using Proxy.Core.Entities;

namespace Proxy.Infrastructure;

public class CustomerRepository : ICustomerRepository {
    public List<Customer> GetBlockedCustomers() {
        return [
            new("Fulano", DateTime.Now.AddYears(-20)),
            new("Fulano", DateTime.Now.AddYears(-30)),
            new("Fulano", DateTime.Now.AddYears(-40))
        ];
    }
}
