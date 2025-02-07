using Mediator.Application.Mediator;
using Mediator.Application.Models;
using Mediator.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(ICqrsMediator mediator) : ControllerBase {
    private readonly ICqrsMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        GetAllProductsQuery query = new();
        GetAllProductsQueryHandler handler = new();

        ProductViewModel result = await handler.Handle(query);

        return this.Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) {
        GetProductByIdQuery query = new(id);
        GetProductByIdQueryHandler handler = new();

        ProductDetailsViewModel result = await handler.Handle(query);

        if (result is null) return this.NotFound();

        return this.Ok(result);
    }

    [HttpGet("with-mediator")]
    public async Task<IActionResult> GetAllWithMediator() {
        GetAllProductsQuery query = new();

        IMediatorResult result = await this._mediator.Handle(query);

        return this.Ok(result);
    }

    [HttpGet("{id}/with-mediator")]
    public async Task<IActionResult> GetByIdWithMediator(Guid id) {
        GetProductByIdQuery query = new(id);

        IMediatorResult result = await this._mediator.Handle(query);

        return this.Ok(result);
    }
}
