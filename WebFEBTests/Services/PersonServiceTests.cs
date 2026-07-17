using Microsoft.Extensions.Logging.Abstractions;
using WebFEB.Models;

namespace WebFEB.Services.Tests;

[TestClass]
public class PersonServiceTests
{
    [TestMethod]
    public async Task AddPersonAsyncAddsPersonToStorage()
    {
        ChangeService changeService = new(NullLogger<ChangeService>.Instance);
        PersonService service = new(changeService);

        PersonDTO person = new()
        {
            Email = "test@test.com",
            Name = "Test User",
            Credit = 50
        };

        await service.AddPersonAsync(person);
        List<PersonDTO> people = await service.GetAllPersonsAsync();

        Assert.AreEqual(4, people.Count);
        Assert.AreEqual("test@test.com", people[3].Email);
    }
}
