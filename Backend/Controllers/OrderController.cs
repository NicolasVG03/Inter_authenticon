using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Controllers;

[ApiController]
[Route("order")]
public class OrderControllers : ControllerBase
{
    private DBauthenticon db;

    public OrderControllers(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Orders
                    .Include(customer => customer.Customer)
                    .ToList());
    }

    [HttpPost]
    public ActionResult Create(Order order)
    {
        db.Orders.Add(order);
        db.SaveChanges();
        return Created(order.OrderID.ToString(), order);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Order orderUpdate)
    {
        Order? orderInTable = db.Orders.Find(id);

        if (orderInTable == null)
            return NotFound();

        orderInTable.TotalPriceOrder = orderUpdate.Status;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        Order? order = db.Orders.Find(id);

        if (order == null)
            return NotFound();

        db.Remove(order);
        db.SaveChanges();

        return Ok();
    }
}