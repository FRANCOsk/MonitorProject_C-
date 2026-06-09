using WebFEB.Enums;
using WebFEB.Models;

namespace WebFEB.Services.Tests
{
    [TestClass()]
    public class ChangeServiceTests
    {

        [TestMethod()]
        public void TrackChangeTest()
        {
            ChangeService changeService = new ChangeService();
            PersonService service = new PersonService(changeService);

            var person = new PersonDTO
            {
                Name = "John Doe",
                Email = "test@test.sk",
                Credit = 100.0
            };

            service.AddPersonAsync(person).Wait();


            var changes = changeService.GetAllChangesAsync().Result;
            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(ChangeTypes.Added, changes[0].ChangeType);

        }
    }
}