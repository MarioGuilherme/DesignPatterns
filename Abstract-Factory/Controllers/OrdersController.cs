using AbstractFactory.Infrastructure;
using AbstractFactory.Infrastructure.Payments;
using AbstractFactory.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace AbstractFactory.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController(IOrderAbstractFactoryFactory orderAbstractFactoryFactory, IPaymentServiceFactory paymentServiceFactory) : ControllerBase {
    private readonly IOrderAbstractFactoryFactory _orderAbstractFactoryFactory = orderAbstractFactoryFactory;
    private readonly IPaymentServiceFactory _paymentServiceFactory = paymentServiceFactory;

    //[HttpPost] // Sem o IOrderAbstractFactoryFactory
    //public IActionResult Post(
    //    [FromServices] InternationalOrderAbstractFactory internationalOrderAbstractFactory,
    //    [FromServices] NationalOrderAbstractFactory nationalOrderAbstractFactory,
    //    OrderInputModel model
    //) {
    //    IOrderAbstractFactory orderAbstractFactory;

    //    if (model.IsInternational is not null && model.IsInternational.Value)
    //        orderAbstractFactory = internationalOrderAbstractFactory;
    //    else
    //        orderAbstractFactory = nationalOrderAbstractFactory;

    //    object paymentResult = orderAbstractFactory
    //        .GetPaymentService(model.PaymentInfo.PaymentMethod)
    //        .Process(model);

    //    orderAbstractFactory
    //        .GetDeliveryService()
    //        .Deliver(model);

    //    return this.NoContent();
    //}

    [HttpPost]
    public IActionResult Post(OrderInputModel model) {
        IOrderAbstractFactory orderAbstractFactory = this._orderAbstractFactoryFactory.GetAbstractFactory(model.IsInternational!.Value);

        object paymentResult = orderAbstractFactory
            .GetPaymentService(model.PaymentInfo.PaymentMethod)
            .Process(model);

        orderAbstractFactory
            .GetDeliveryService()
            .Deliver(model);

        return this.NoContent();
    }
}