namespace Composite.Core.Entities;

public class ManagerComposite(string name, string role, decimal expenses) : EmployeeComponent(name, role, expenses) {
    private readonly List<EmployeeComponent> _children = [];

    public override decimal GetExpenses() {
        return _children.Sum(c => c.GetExpenses()) + this.Expenses;
    }

    public void Add(EmployeeComponent component) {
        _children.Add(component);
    }

    public void Remove(EmployeeComponent component) {
        _children.Remove(component);
    }
}
