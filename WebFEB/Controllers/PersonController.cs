using Microsoft.AspNetCore.Mvc;
using WebFEB.Enums;
using WebFEB.Models;
using WebFEB.Services;

namespace WebFEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController: ControllerBase
    {
        private IPersonService _personService;
        private IChangeService _changeService;

        public PersonController(IPersonService personService, IChangeService changeService)
        {
            _personService = personService;
            _changeService = changeService;
        }

        [HttpGet(Name = "GetPersons")]
        public async Task<IEnumerable<PersonDTO>> Get()
        {
            return await _personService.GetAllPersonsAsync();
        }

        [HttpPost(Name = "AddPerson")]
        public async Task AddPerson(PersonDTO person)
        {
            DateTime start = DateTime.Now;

            if(person.Credit < 0)
            {
                await _changeService.TrackChange(new ChangeDTO() { ChangeType = ChangeTypes.Warning, Email = person.Email, Message = "Person dont have credit" });

            }

            if(string.IsNullOrEmpty(person.Email))
            {
                await _changeService.TrackChange(new ChangeDTO() { ChangeType = ChangeTypes.Error, Email = person.Email, Message = "Person email is required" });

                return;
            }

            await _personService.AddPersonAsync(person);
            DateTime end = DateTime.Now;
            await _changeService.TrackChange(new ChangeDTO() { ChangeType = ChangeTypes.Added, Email = person.Email, Message = $"Person added in {(end - start).TotalMilliseconds} milliseconds" });

        }

        [HttpPut(Name = "UpdatePerson")]
        public async Task UpdatePerson(PersonDTO person)
        {
            DateTime start = DateTime.Now;

            await _personService.UpdatePersonAsync(person.Email, person);

            DateTime end = DateTime.Now;
            await _changeService.TrackChange(new ChangeDTO() { ChangeType = ChangeTypes.Updated, Email = person.Email, Message = $"Person updated in {(end - start).TotalMilliseconds} milliseconds" });
        }
        [HttpDelete(Name = "DeletePerson")]
        public async Task DeletePerson(string email)
        {

            await _personService.DeletePersonAsync(email);

        }

    }
}
