using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Controllers;

[ApiController]
[Route("orderproduct")]
public class OrderProductControllers : ControllerBase
{
    private DBauthenticon db;

    public OrderProductControllers(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.OrderProducts
                    .Include(order => order.Order)
                    .Include(product => product.Product)
                    .ToList());
    }

    [HttpPost]
    public ActionResult Create(OrderProducts orderproducts)
    {
        Product? product = db.Products.Where(product => product.ProductID == orderproducts.ProductID).FirstOrDefault();

        if (product == null)
            return NotFound("Produto não encontrado");


        orderproducts.TotalPriceProduct = orderproducts.QuantityOrdered * product.UnitPrice;

        db.OrderProducts.Add(orderproducts);
        db.SaveChanges();

        return Created(orderproducts.OrderID.ToString(), orderproducts);
    }

    [HttpPut]
    [Route("{idOrder}/{idProduct}")]
    public ActionResult Update(int idProduct, int idOrder, OrderProducts orderUpdate)
    {
        OrderProducts? orderproductInTable = db.OrderProducts.Find(idProduct, idOrder);

        if (orderproductInTable == null)
            return NotFound();

        orderproductInTable.QuantityOrdered = orderUpdate.QuantityOrdered;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    [Route("{idOrder}/{idProduct}")]
    public ActionResult Delete(int idOrder, int idProduct)
    {
        OrderProducts? orderproducts = db.OrderProducts.Find(idOrder, idProduct);

        if (orderproducts == null)
            return NotFound(idOrder);

        db.Remove(orderproducts);
        db.SaveChanges();

        return Ok();
    }
}