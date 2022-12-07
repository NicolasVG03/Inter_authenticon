using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Controllers;

[ApiController]
[Route("administrator")]
public class AdministratorController : ControllerBase
{
    private DBauthenticon db;

    public AdministratorController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read(int id)
    {
        Administrator? administrator = db.Administrators.Find(id);

        return Ok(administrator);
    }

    [HttpPost]
    public ActionResult Create(Administrator administrator)
    {
        db.Administrators.Add(administrator);
        db.SaveChanges();
        return Created(administrator.UserID.ToString(), administrator);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Administrator administratorUpdate)
    {
        Administrator? administratorInTable = db.Administrators.Find(id);

        if (administratorInTable == null)
            return NotFound();

        administratorInTable.Name = administratorUpdate.Name;
        administratorInTable.Email = administratorUpdate.Email;
        administratorInTable.Password = administratorUpdate.Password;
        administratorInTable.Phones = administratorUpdate.Phones;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        Administrator? administrator = db.Administrators.Find(id);

        if (administrator == null)
            return NotFound();

        db.Remove(administrator);
        db.SaveChanges();

        return Ok();
    }
}