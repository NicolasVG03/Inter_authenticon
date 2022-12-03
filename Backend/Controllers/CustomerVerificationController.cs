using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;


namespace authenticon.Controllers;

[ApiController]
[Route("customerVerification")]
public class CustomerVerificationController : ControllerBase
{
    private DBauthenticon db;

    public CustomerVerificationController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read(string email)
    {
        Customer? customer = db.Customers.Where(c => c.Email == email).Include(c => c.Phones).FirstOrDefault();

        if (customer != null)
            return Ok(false);

        return Ok(true);
    }

}