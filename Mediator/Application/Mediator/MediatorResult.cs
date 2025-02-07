namespace Mediator.Application.Mediator;

public class MediatorResult(object data, bool success) : IMediatorResult {
    public object Data { get; private set; } = data;
    public bool Success { get; private set; } = success;
}
