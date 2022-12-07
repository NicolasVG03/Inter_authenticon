using Microsoft.AspNetCore.Mvc;
using authenticon.Models;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Controllers;

[ApiController]
[Route("product")]
public class ProductControllers : ControllerBase
{
    private DBauthenticon db;

    public ProductControllers(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Products
                    .Include(collection => collection.Collection)
                    .ToList());
    }

    [HttpPost]
    public ActionResult Create([FromForm] Product product)
    {
        string pathImage = product.Name + ".jpg";

        product.ImageFile.CopyToAsync(new FileStream(pathImage, FileMode.Create));
        product.ImageUrl = pathImage;

        db.Products.Add(product);
        db.SaveChanges();
        return Created(product.ProductID.ToString(), product);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Product productUpdate)
    {
        Product? productInTable = db.Products.Find(id);

        if (productInTable == null)
            return NotFound();

        productInTable.Name = productUpdate.Name;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        Product? product = db.Products.Find(id);

        if (product == null)
            return NotFound();

        db.Remove(product);
        db.SaveChanges();

        return Ok();
    }
}