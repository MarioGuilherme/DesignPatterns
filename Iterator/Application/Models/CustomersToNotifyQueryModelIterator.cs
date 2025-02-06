using Iterator.Core.Entities;
using System.Collections;

namespace Iterator.Application.Models;

public class CustomersToNotifyQueryModelIterator(List<Customer> customer, string generatedBy) : IEnumerable<KeyValuePair<string, string>> {
    public string? this[string customerFullName] {
        get => this._customerAndEmailDict.TryGetValue(customerFullName, out string? value)
            ? value
            : null;
        set => this._customerAndEmailDict[customerFullName] = value;
    }

    private Dictionary<string, string> _customerAndEmailDict = customer.ToDictionary(c => c.FullName, c => c.Email);
    public DateTime GeneratedAt { get; private set; } = DateTime.Now;
    public string GeneratedBy { get; private set; } = generatedBy;

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => this._customerAndEmailDict.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}