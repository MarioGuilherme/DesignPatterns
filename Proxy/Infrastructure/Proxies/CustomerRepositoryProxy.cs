using Proxy.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Proxy.Infrastructure.Proxies;

// Parecido com o padrão Decorator, mas com conceito de uso diferente, aqui valida-se para acessar o obj (dado)
public class CustomerRepositoryProxy(ICustomerRepository repository, IMemoryCache cache, IHttpContextAccessor httpContextAccessor) : ICustomerRepository {
    private readonly ICustomerRepository _repository = repository;
    private readonly IMemoryCache _cache = cache;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public List<Customer>? GetBlockedCustomers() {
        HttpContext? httpContext = _httpContextAccessor.HttpContext;

        if (httpContext is null) return null;

        if (httpContext.Request.Headers["x-role"] != "admin") return null;

        List<Customer>? blockedCustomers = this._cache.GetOrCreate("blocked-customers", c => {
            return _repository.GetBlockedCustomers();
        });

        return blockedCustomers;
    }
}
