using WebFEB.Models;

namespace WebFEB.Services.Tests
{
    [TestClass()]
    public class PersonServiceTests
    {

        [TestMethod()]
        public void AddPersonAsyncTest()
        {

            ChangeService changeService = new ChangeService();
            PersonService service = new PersonService(changeService);

            var person = new PersonDTO
            {
                Email = "test@test.com",
                Name = "Test User",
                Credit = 50
            };

            // Act
            service.AddPersonAsync(person);

            var persons = service.GetAllPersonsAsync().Result;
            // Assert
            Assert.AreEqual(4, persons.Count);
            Assert.AreEqual("test@test.com", persons[3].Email);

        }


    }
}