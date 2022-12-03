using Microsoft.AspNetCore.Mvc;
using authenticon.Models;

namespace authenticon.Controllers;

[ApiController]
[Route("phone")]
public class PhoneController : ControllerBase
{
    private DBauthenticon db;

    public PhoneController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Phones.ToList());
    }

    [HttpPost]
    public ActionResult Create(Phone phone)
    {
        db.Phones.Add(phone);
        db.SaveChanges();
        return Created(phone.PersonID.ToString(), phone);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(string number, Phone PhoneUpdate)
    {
        Phone? PhoneInTable = db.Phones.Find(number);

        if (PhoneInTable == null)
            return NotFound();

        PhoneInTable.Number = PhoneUpdate.Number;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(string number)
    {
        Phone? Phone = db.Phones.Find(number);

        if (Phone == null)
            return NotFound();

        db.Remove(Phone);
        db.SaveChanges();

        return Ok();
    }
}