using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;


namespace authenticon.Controllers;

[ApiController]
[Route("customer")]
public class CustomerControllers : ControllerBase
{
    private DBauthenticon db;

    public CustomerControllers(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Read(int id)
    {
        return Ok(db.Customers.Where(c => c.UserID == id).Include(c => c.Phones).FirstOrDefault());
    }

    [HttpPost]
    public ActionResult Create(Customer customer)
    {
        db.Customers.Add(customer);
        db.SaveChanges();

        return Created(customer.UserID.ToString(), customer);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Customer customerUpdate)
    {
        Customer? customerInTable = db.Customers.Find(id);

        if (customerInTable == null)
            return NotFound();

        customerInTable.Name = customerUpdate.Name;
        customerInTable.Email = customerUpdate.Email;
        customerInTable.Gender = customerUpdate.Gender;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        Customer? customer = db.Customers.Find(id);

        if (customer == null)
            return NotFound();

        db.Remove(customer);
        db.SaveChanges();

        return Ok();
    }
}