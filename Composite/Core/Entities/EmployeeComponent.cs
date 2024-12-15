namespace Composite.Core.Entities;

public abstract class EmployeeComponent(string name, string role, decimal expenses) {
    public string Name { get; private set; } = name;
    public string Role { get; private set; } = role;
    public decimal Expenses { get; private set; } = expenses;
    public abstract decimal GetExpenses();
}
