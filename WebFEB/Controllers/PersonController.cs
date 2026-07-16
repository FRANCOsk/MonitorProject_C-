using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebFEB.Enums;
using WebFEB.Models;
using WebFEB.Services;

namespace WebFEB.Controllers;

[ApiController]
[Route("api/people")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly IChangeService _changeService;

    public PersonController(IPersonService personService, IChangeService changeService)
    {
        _personService = personService;
        _changeService = changeService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<PersonDTO>>> GetPeople()
    {
        List<PersonDTO> people = await _personService.GetAllPersonsAsync();
        return Ok(people);
    }

    [HttpPost]
    public async Task<ActionResult<PersonDTO>> AddPerson(PersonDTO person)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        if (person.Credit < 0)
        {
            await _changeService.TrackChange(new ChangeDTO
            {
                ChangeType = ChangeTypes.Warning,
                Email = person.Email,
                Message = "Person has a negative credit balance."
            });
        }

        await _personService.AddPersonAsync(person);
        stopwatch.Stop();

        await _changeService.TrackChange(new ChangeDTO
        {
            ChangeType = ChangeTypes.Added,
            Email = person.Email,
            Message = $"Person request completed in {stopwatch.Elapsed.TotalMilliseconds:F2} ms."
        });

        return StatusCode(StatusCodes.Status201Created, person);
    }

    [HttpPut("{email}")]
    public async Task<IActionResult> UpdatePerson(string email, PersonDTO person)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        await _personService.UpdatePersonAsync(email, person);
        stopwatch.Stop();

        await _changeService.TrackChange(new ChangeDTO
        {
            ChangeType = ChangeTypes.Updated,
            Email = email,
            Message = $"Person update request completed in {stopwatch.Elapsed.TotalMilliseconds:F2} ms."
        });

        return NoContent();
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> DeletePerson(string email)
    {
        await _personService.DeletePersonAsync(email);
        return NoContent();
    }
}
