using ChainOfResponsibility.Application.Models;
using ChainOfResponsibility.Infrastructure.Products;

namespace ChainOfResponsibility.Application.ChainOfResponsibility;

public class ValidateStockHandler(IProductRepository repository) : OrderHandlerBase, IOrderHandler {
    private readonly IProductRepository _repository = repository;

    public override bool Handle(OrderInputModel model) {
        Console.WriteLine($"Invoking ValidateStockHandler.Handle");

        Dictionary<Guid, int> itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
        bool hasStock = _repository.HasStock(itemsDictionary);

        if (!hasStock)
            return false;

        return base.Handle(model);
    }
}