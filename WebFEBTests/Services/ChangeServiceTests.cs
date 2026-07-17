using Microsoft.Extensions.Logging.Abstractions;
using WebFEB.Enums;
using WebFEB.Models;
using WebFEB.Storage;

namespace WebFEB.Services.Tests;

[TestClass]
public class ChangeServiceTests
{
    [TestInitialize]
    public void ResetChangeStorage()
    {
        MonitorStorage.Changes.Clear();
    }

    [TestMethod]
    public async Task TrackChangeRecordsAddedPerson()
    {
        ChangeService changeService = new(NullLogger<ChangeService>.Instance);
        PersonService service = new(changeService);

        PersonDTO person = new()
        {
            Name = "John Doe",
            Email = "test@test.sk",
            Credit = 100.0
        };

        await service.AddPersonAsync(person);
        List<ChangeDTO> changes = await changeService.GetAllChangesAsync();

        Assert.AreEqual(1, changes.Count);
        Assert.AreEqual(ChangeTypes.Added, changes[0].ChangeType);
    }
}
