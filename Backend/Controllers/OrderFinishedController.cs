using Microsoft.AspNetCore.Mvc;
using authenticon.Models;

namespace authenticon.Controllers;

[ApiController]
[Route("orderfinished")]
public class OrderFinishedController : ControllerBase
{
    private DBauthenticon db;

    public OrderFinishedController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id)
    {
        Order? orderInTable = db.Orders.Find(id);

        if (orderInTable == null)
            return NotFound();

        var products = db.OrderProducts.Where(orderId => orderId.OrderID == id);

        foreach (var product in products)
        {
            orderInTable.TotalPriceOrder += product.TotalPriceProduct;
        }

        db.SaveChanges();
        return Ok();
    }
}