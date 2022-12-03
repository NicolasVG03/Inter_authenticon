using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Controllers;

[ApiController]
[Route("listproduct/")]
public class ListProductByFilterController : ControllerBase
{
    private DBauthenticon db;

    public ListProductByFilterController(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("{id}/size={size}")]
    public ActionResult ListProductsBySize(int id, string size)
    {
        return Ok(db.Products.Where(product => product.CollectionID == id && product.Size == size)
                    .Include(collection => collection.Collection)
                    .Include(category => category.Category)
                    .ToList());
    }

    [HttpGet]
    [Route("{id}/price={option}")]
    public ActionResult ListProductsBySize(int id, int option)
    {
        if (option == 1)
        {
            return Ok(db.Products.Where(product => product.CollectionID == id && product.UnitPrice <= 100)
                                    .Include(collection => collection.Collection)
                                    .Include(category => category.Category)
                                    .ToList());
        }
        else if (option == 2)
        {
            return Ok(db.Products.Where(product => product.CollectionID == id && product.UnitPrice > 100 && product.UnitPrice <= 150)
                                        .Include(collection => collection.Collection)
                                        .Include(category => category.Category)
                                        .ToList());
        }
        else
        {
            return Ok(db.Products.Where(product => product.CollectionID == id && product.UnitPrice >= 150)
                                                    .Include(collection => collection.Collection)
                                                    .Include(category => category.Category)
                                                    .ToList());
        }

    }
}