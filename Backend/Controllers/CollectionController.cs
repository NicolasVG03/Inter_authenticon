using Microsoft.AspNetCore.Mvc;
using authenticon.Models;

namespace authenticon.Controllers;

[ApiController]
[Route("collection")]
public class CollectionControllers : ControllerBase
{
    private DBauthenticon db;

    public CollectionControllers(DBauthenticon db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Collections.Where(c => c.CollectionID > 5).ToList());
    }

    [HttpPost]
    public ActionResult Create(Collection collection)
    {
        db.Collections.Add(collection);
        db.SaveChanges();

        return Created(collection.CollectionID.ToString(), collection);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Collection collectionUpdate)
    {
        Collection? collectionInTable = db.Collections.Find(id);

        if (collectionInTable == null)
            return NotFound();

        collectionInTable.Name = collectionUpdate.Name;

        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        Collection? collection = db.Collections.Find(id);

        if (collection == null)
            return NotFound();

        db.Remove(collection);
        db.SaveChanges();

        return Ok();
    }
}