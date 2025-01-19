using ChainOfResponsibility.Application.Models;

namespace ChainOfResponsibility.Application.ChainOfResponsibility;

public interface IOrderHandler {
    bool Handle(OrderInputModel model);
    IOrderHandler SetNext(IOrderHandler handler);
}