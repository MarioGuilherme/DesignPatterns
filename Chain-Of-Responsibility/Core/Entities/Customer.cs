namespace ChainOfResponsibility.Core.Entities;

public class Customer(string fullName, DateTime birthDate, string email) {
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string FullName { get; private set; } = fullName;
    public DateTime BirthDate { get; private set; } = birthDate;
    public CustomerStatus Status { get; private set; }
    public string Email { get; private set; } = email;

    public bool IsAllowedToBuy() {
        return Status != CustomerStatus.Blocked;
    }
}

public enum CustomerStatus {
    Active = 1,
    Blocked,
    Restricted,
    Cancelled
}