using Microsoft.AspNetCore.Mvc;
using authenticon.Models;

namespace authenticon.Controllers;

[ApiController]
[Route("login")]
public class LoginController : ControllerBase
{
    private DBauthenticon db;

    public LoginController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Login(string email, string password)
    {
        Person? person;

        Customer? customer = db.Customers.Where(person => person.Email == email)
                                         .Where(person => person.Password == password)
                                         .FirstOrDefault();

        if (customer == null)
        {

            Administrator? administrator = db.Administrators
                                            .Where(person => person.Email == email)
                                            .Where(person => person.Password == password)
                                            .FirstOrDefault();

            if (administrator == null)
                return NotFound("Usuário não encontrado");

            person = db.People.Where(person => person.UserID == administrator.UserID).FirstOrDefault();
            return Ok(person);
        }
        person = db.People.Where(person => person.UserID == customer.UserID).FirstOrDefault();
        return Ok(person);
    }
}