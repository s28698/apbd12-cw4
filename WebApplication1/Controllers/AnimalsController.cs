using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    
    // GET: api/animals
    [HttpGet]
    public ActionResult<List<Animal>> GetAll()
    {
        return Database.Animals.ToList();
    }

    
    // GET: api/animals/{id}
    [HttpGet("{id}")]
    public ActionResult<Animal> GetById(int id)
    {
        var a = Database.Animals.FirstOrDefault(x => x.Id == id);
        if (a == null) return NotFound();
        return a;
    }

    
    // GET: api/animals/search?name=xxx
    [HttpGet("search")]
    public ActionResult<List<Animal>> SearchByName([FromQuery] string name)
    {
        var list = Database.Animals
            .Where(x => x.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase))
            .ToList();
        
        return list;
    }

    
    // POST: api/animals
    [HttpPost]
    public ActionResult<Animal> Create(Animal newAnimal)
    {
        newAnimal.Id = Database.Animals.Max(x => x.Id) + 1;
        Database.Animals.Add(newAnimal);
        return Ok();
    }
    
    
    // PUT: api/animals/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Animal updated)
    {
        var idx = Database.Animals.FindIndex(x => x.Id == id);
        if (idx == -1) return NotFound();

        updated.Id = id;
        Database.Animals[idx] = updated;
        return NoContent();
    }

    
    // DELETE: api/animals/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var a = Database.Animals.FirstOrDefault(x => x.Id == id);
        if (a == null) return NotFound();

        Database.Visits.RemoveAll(v => v.AnimalId == id);
        Database.Animals.Remove(a);
        return NoContent();
    }
}