using Microsoft.AspNetCore.Mvc;
using authenticon.Models;

namespace authenticon.Controllers;

[ApiController]
[Route("collectionChosen")]
public class CollectionChosenController : ControllerBase
{
    private DBauthenticon db;

    public CollectionChosenController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read(string name)
    {
        return Ok(db.Collections.Where(c => c.Name == name).FirstOrDefault());
    }
}