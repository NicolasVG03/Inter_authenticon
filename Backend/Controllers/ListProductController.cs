using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Controllers;

[ApiController]
[Route("listproduct")]
public class ListProductController : ControllerBase
{
    private DBauthenticon db;

    public ListProductController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult ListProductsByCollection(int id)
    {
        return Ok(db.Products.Where(collection => collection.CollectionID == id)
                    .Include(collection => collection.Collection)
                    .Include(category => category.Category)
                    .Include(administrator => administrator.Administrator)
                    .ToList());
    }
}