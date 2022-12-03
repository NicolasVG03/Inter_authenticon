using Microsoft.AspNetCore.Mvc;
using authenticon.Models;

namespace authenticon.Controllers;

[ApiController]
[Route("category")]
public class CategoryControllers : ControllerBase
{
    private DBauthenticon db;

    public CategoryControllers(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Categories.ToList());
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
        db.Categories.Add(category);
        db.SaveChanges();

        return Created(category.CategoryID.ToString(), category);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Category categoryUpdate)
    {
        Category? categoryInTable = db.Categories.Find(id);

        if (categoryInTable == null)
            return NotFound();

        categoryInTable.Name = categoryUpdate.Name;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        Category? category = db.Categories.Find(id);

        if (category == null)
            return NotFound();

        db.Remove(category);
        db.SaveChanges();

        return Ok();
    }
}