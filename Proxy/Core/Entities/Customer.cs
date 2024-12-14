namespace Proxy.Core.Entities;

public class Customer(string fullName, DateTime birthDate) {
    public string FullName { get; private set; } = fullName;
    public DateTime BirthDate { get; private set; } = birthDate;
}
