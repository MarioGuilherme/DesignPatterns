using ChainOfResponsibility.Application.Models;

namespace ChainOfResponsibility.Application.ChainOfResponsibility;

public abstract class OrderHandlerBase : IOrderHandler {
    private IOrderHandler? _nextHandler;
    public virtual bool Handle(OrderInputModel model) {
        if (_nextHandler == null)
            return true;

        bool result = _nextHandler.Handle(model);

        return result;
    }

    public IOrderHandler SetNext(IOrderHandler step) {
        _nextHandler = step;

        return step;
    }
}