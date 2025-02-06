using Iterator.Core.Entities;

namespace Iterator.Infrastructure;

public class CustomerRepository : ICustomerRepository {
    public List<Customer> GetBlockedCustomers() => [
        new("M�rio 1", DateTime.Now.AddYears(-20), "mario1@mail.com"),
        new("M�rio 2", DateTime.Now.AddYears(-30), "mario2@mail.com"),
        new("M�rio 3", DateTime.Now.AddYears(-40), "mario3@mail.com")
    ];

    public Customer GetCustomerById(Guid id) => new("M�rio", DateTime.Now.AddYears(-30), "mario3@mail.com");
}
