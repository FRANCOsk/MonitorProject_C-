using WebFEB.Enums;
using WebFEB.Models;
using WebFEB.Storage;

namespace WebFEB.Services
{
    public class PersonService: IPersonService
    {
        private PersonStorage storage;

        public async Task AddPersonAsync(PersonDTO person)
        {


            storage.Persons.Add(person);

            await _changeService.TrackChange(new ChangeDTO
            {

                ChangeType = ChangeTypes.Added,
                Email = person.Email,
                Timestamp = DateTime.UtcNow,
                Message = $"Added person with email {person.Email} and name {person.Name}."

            });

        }

        private readonly IChangeService _changeService;
        public PersonService(IChangeService changeService)
        {

            storage = new PersonStorage();
            _changeService = changeService;
        }

        public async Task DeletePersonAsync(string email)
        {
            var person = storage.Persons.SingleOrDefault(e => e.Email == email);

            if(person != null)
            {

                storage.Persons.Remove(person);
                await _changeService.TrackChange(new ChangeDTO
                {
                    ChangeType = ChangeTypes.Deleted,
                    Email = person.Email,
                    Timestamp = DateTime.UtcNow,
                    Message = $"Deleted person with email {person.Email} and name {person.Name}."
                });

            }

        }

        public async Task<List<PersonDTO>> GetAllPersonsAsync()
        {
            await _changeService.TrackChange(new ChangeDTO
            {
                ChangeType = ChangeTypes.Info,
                Email = null,
                Timestamp = DateTime.UtcNow,
                Message = $"Retrieved all persons."
            });
            return storage.Persons;

        }

        public async Task UpdatePersonAsync(string email, PersonDTO updatedPerson)
        {
            var person = storage.Persons.SingleOrDefault(e => e.Email == email);

            if(person != null)
            {
                await _changeService.TrackChange(new ChangeDTO
                {
                    ChangeType = ChangeTypes.Updated,
                    Email = person.Email,
                    Timestamp = DateTime.UtcNow,
                    Message = $"Updated person with email {person.Email} to name {person.Name} and credit {person.Credit}."
                });

                person.Name = updatedPerson.Name;
                person.Credit = updatedPerson.Credit;
            }

        }
    }
}
