using crud_person_c_.Models;
using crud_person_c_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonService _service;

    public PersonController(PersonService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> PostPerson(Person person)
    {
        await _service.CreatePersonAsync(person);
        return CreatedAtAction(nameof(GetByIdPerson), new { id = person.Id }, person);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPerson()
    {
        var people = await _service.GetAllAsync();

        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdPerson(long id)
    {
        var person = await _service.GetByIdAsync(id);
        
        if (person == null) return NotFound("Pessoa não encontrada");

        return Ok(person);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(long id, [FromBody] Person updatedPerson)
    {
        var existPerson = await _service.GetByIdAsync(id);

        if (existPerson == null) return NotFound("Pessoa não encontrada");
        
        if (id != updatedPerson.Id) return BadRequest("O ID da URL não corresponde ao ID do Person.");

        await _service.UpdatePersonAsync(id, updatedPerson);
        return StatusCode(201, existPerson);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(long id)
    {
        var person = await _service.GetByIdAsync(id);

        if (person == null) return NotFound("Pessoa não encontrada");

        await _service.DeletePersonAsync(person.Id);
        return NoContent();
    }
    
}