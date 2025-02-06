using Iterator.Core.Entities;

namespace Iterator.Infrastructure;

public interface ICustomerRepository {
    List<Customer> GetBlockedCustomers();
    Customer GetCustomerById(Guid id);
}
