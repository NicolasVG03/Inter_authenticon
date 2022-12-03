using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Controllers;

[ApiController]
[Route("shoppingcart")]
public class ShoppingCartController : ControllerBase
{
    private DBauthenticon db;

    public ShoppingCartController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        return Ok(db.OrderProducts
                    .Include(product => product.Product)
                    .Where(orderId => orderId.OrderID == id)
                    .ToList());
    }

    [HttpPost]
    public ActionResult Create(OrderProducts orderProduct)
    {
        Product? product = db.Products.Find(orderProduct.ProductID);
        if (product == null)
            return NotFound();

        orderProduct.TotalPriceProduct = product.UnitPrice * orderProduct.QuantityOrdered;
        db.OrderProducts.Add(orderProduct);
        db.SaveChanges();
        return Created(orderProduct.OrderID.ToString(), orderProduct);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int idOrder, int idProduct, OrderProducts productUpdate)
    {
        OrderProducts? productInTable = db.OrderProducts.Find(idOrder, idProduct);

        if (productInTable == null)
            return NotFound();

        productInTable.QuantityOrdered = productUpdate.QuantityOrdered;
        Product? product = db.Products.Find(idProduct);

        if (product == null)
            return NotFound();

        productInTable.TotalPriceProduct = product.UnitPrice * productUpdate.QuantityOrdered;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    [Route("{idorder}/{idproduct}")]
    public ActionResult Delete(int idOrder, int idProduct)
    {
        OrderProducts? productOrder = db.OrderProducts.Find(idOrder, idProduct);

        if (productOrder == null)
            return NotFound();

        db.Remove(productOrder);
        db.SaveChanges();

        return Ok();
    }
}