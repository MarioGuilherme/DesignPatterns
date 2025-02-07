using Mediator.Application.Models;
using Mediator.Queries;

namespace Mediator.Application.Mediator;

public class CqrsMediator : ICqrsMediator {
    public async Task<IMediatorResult> Handle(IQuery query) {
        if (query is null) return new MediatorResult(null, false);

        if (query is GetProductByIdQuery) {
            GetProductByIdQueryHandler handler = new();
            ProductDetailsViewModel result = await handler.Handle((query as GetProductByIdQuery)!);

            return new MediatorResult(result, true);
        }
        
        if (query is GetAllProductsQuery) {
            GetAllProductsQueryHandler handler = new();
            ProductViewModel result = await handler.Handle((query as GetAllProductsQuery)!);

            return new MediatorResult(result, true);
        }

        return new MediatorResult(null, false);
    }

    public IMediatorResult Handle(ICommand command) {
        if (command is null)
            return new MediatorResult(null, false);

        //if (command is CreateProductCommand) {
        //    CreateProductCommandHandler handler = new();
        //    int result = await handler.Handle((command as CreateProductCommand)!);

        //    return new MediatorResult(result, true);
        //}

        return new MediatorResult(null, false);
    }
}
