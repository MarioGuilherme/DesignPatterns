using Mediator.Application.Mediator;

namespace Mediator.Queries;

public class GetProductByIdQuery(Guid id) : IQuery {
    public Guid Id { get; private set; } = id;
}
