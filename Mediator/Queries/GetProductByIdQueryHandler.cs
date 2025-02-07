using Mediator.Application.Models;

namespace Mediator.Queries;

public class GetProductByIdQueryHandler {
    public Task<ProductDetailsViewModel> Handle(GetProductByIdQuery query) => Task.FromResult(new ProductDetailsViewModel());
}
