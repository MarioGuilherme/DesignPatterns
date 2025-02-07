namespace Mediator.Application.Mediator;

public interface ICqrsMediator {
    Task<IMediatorResult> Handle(IQuery query);
    Task<IMediatorResult> Handle(ICommand command);
}
