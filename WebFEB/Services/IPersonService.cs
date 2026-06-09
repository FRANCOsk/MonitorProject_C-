

using WebFEB.Models;

namespace WebFEB.Services
{
    public interface IPersonService
    {
            Task<List<PersonDTO>> GetAllPersonsAsync();
            Task AddPersonAsync(PersonDTO person);
            Task UpdatePersonAsync(string email, PersonDTO updatedPerson);
            Task DeletePersonAsync(string email);
    }
}
