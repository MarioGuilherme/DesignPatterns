using Mediator.Application.Models;

namespace Mediator.Queries;

public class GetAllProductsQueryHandler {
    public Task<ProductViewModel> Handle(GetAllProductsQuery query) => Task.FromResult(new ProductViewModel());
}
