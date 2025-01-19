using ChainOfResponsibility.Application.Models;
using ChainOfResponsibility.Core.Entities;
using ChainOfResponsibility.Infrastructure;

namespace ChainOfResponsibility.Application.ChainOfResponsibility;

public class ValidateCustomerHandler(ICustomerRepository repository) : OrderHandlerBase, IOrderHandler {
    private readonly ICustomerRepository _repository = repository;

    public override bool Handle(OrderInputModel model) {
        Console.WriteLine($"Invoking ValidateCustomerHandler.Handle");

        Customer customer = _repository.GetCustomerById(model.Customer.Id);
        bool customerAllowedToBuy = customer.IsAllowedToBuy();

        if (!customerAllowedToBuy)
            return false;

        return base.Handle(model);
    }
}