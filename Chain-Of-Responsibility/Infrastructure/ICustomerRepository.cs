using ChainOfResponsibility.Core.Entities;

namespace ChainOfResponsibility.Infrastructure;

public interface ICustomerRepository {
    List<Customer> GetBlockedCustomers();
    Customer GetCustomerById(Guid id);
}
