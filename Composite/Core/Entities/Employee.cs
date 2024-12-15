namespace Composite.Core.Entities;

public class Employee(string name, string role, decimal expenses) : EmployeeComponent(name, role, expenses) {
    public override decimal GetExpenses() => this.Expenses;
}
