using Iterator.Core.Entities;

namespace Iterator.Infrastructure;

public class CustomerRepository : ICustomerRepository {
    public List<Customer> GetBlockedCustomers() => [
        new("Mário 1", DateTime.Now.AddYears(-20), "mario1@mail.com"),
        new("Mário 2", DateTime.Now.AddYears(-30), "mario2@mail.com"),
        new("Mário 3", DateTime.Now.AddYears(-40), "mario3@mail.com")
    ];

    public Customer GetCustomerById(Guid id) => new("Mário", DateTime.Now.AddYears(-30), "mario3@mail.com");
}
