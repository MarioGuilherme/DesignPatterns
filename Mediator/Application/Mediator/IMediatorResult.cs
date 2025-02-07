namespace Mediator.Application.Mediator;

public interface IMediatorResult {
    object Data { get; }
    bool Success { get; }
}