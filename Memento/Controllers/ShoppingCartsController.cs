using Memento.Application.Mementos;
using Memento.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Memento.Controllers;

[ApiController]
[Route("api/shopping-carts")]
public class ShoppingCartsController : ControllerBase {
    [HttpPost]
    public IActionResult Save(ShoppingCartInputModel model) {
        // Pode-se guardar o histórico em cache, memória ou banco de dados (SQL ou NoSQL)
        ShoppingCartOriginator originator = new(model.CustomerId, model.Items); // CÓPIA DO 'model'
        ShoppingCartCaretaker shoppingCartCareTaker = new(originator);

        Guid productId1 = new("d60d6a11-faff-419e-b119-4de58f913055");
        Guid productId2 = new("d98329b7-87af-4bea-b6ac-3674f2bc0230");
        Guid productId3 = new("fbb35828-d9ba-4fdf-b9a3-1aaff7a68e30");

        model.Items.Add(new OrderItemInputModel { ProductId = productId1, Quantity = 1 });

        // Fazer backup e atualizar
        shoppingCartCareTaker.Backup(); // Salva o estado ATUAL DO 'model'
        shoppingCartCareTaker.Originator.UpdateCart(model.Items); // Adiciona itens novos no 'model'

        model.Items.Add(new OrderItemInputModel { ProductId = productId2, Quantity = 2 });

        // Fazer backup e atualizar
        shoppingCartCareTaker.Backup();
        shoppingCartCareTaker.Originator.UpdateCart(model.Items);

        model.Items.Add(new OrderItemInputModel { ProductId = productId3, Quantity = 3 });

        // Fazer backup e atualizar
        shoppingCartCareTaker.Backup();
        shoppingCartCareTaker.Originator.UpdateCart(model.Items);

        //shoppingCartCareTaker.Backup();

        shoppingCartCareTaker.PrintHistory();

        shoppingCartCareTaker.Undo();

        shoppingCartCareTaker.PrintHistory();

        return this.NoContent();
    }
}
