using Microsoft.AspNetCore.Mvc;
using authenticon.Models;

namespace authenticon.Controllers;

[ApiController]
[Route("collectionproduct")]
public class CollectionProduct : ControllerBase
{
    private DBauthenticon db;

    public CollectionProduct(DBauthenticon db)
    {
        this.db = db;
    }

    // [HttpGet]
    // public ActionResult Read(int id)
    // {
    //     return Ok(db.Collections.Where(c => c.CollectionID == id).FirstOrDefault());
    // }

}