using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    
    // GET: api/visits/animal/{animalId}
    [HttpGet("animal/{animalId}")]
    public ActionResult<List<Visit>> GetForAnimal(int animalId)
    {
        return Database.Visits.Where(x => x.AnimalId == animalId).ToList();
    }


    // POST: api/visits
    [HttpPost]
    public ActionResult<Visit> Create(Visit newVisit)
    {
        if (Database.Animals.All(a => a.Id != newVisit.AnimalId))
        {
            return BadRequest("Brak zwierzęcia o podanym Id");
        }
        newVisit.Id = Database.Visits.Any() 
            ? Database.Visits.Max(x => x.Id) + 1 
            : 1;

        Database.Visits.Add(newVisit);
        return Ok();
    }

    
    // PUT: api/visits/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Visit updated)
    {
        var idx = Database.Visits.FindIndex(x => x.Id == id);
        if (idx == -1) return NotFound();
        if (!Database.Animals.Any(a => a.Id == updated.AnimalId))
            return BadRequest("Nie ma takiego zwierzęcia.");

        updated.Id = id;
        Database.Visits[idx] = updated;
        return NoContent();
    }
    
    
    [HttpGet("{id}")]
    public ActionResult<Visit> GetById(int id)
    {
        var v = Database.Visits.FirstOrDefault(x => x.Id == id);
        if (v == null) return NotFound();
        return v;
    }
}