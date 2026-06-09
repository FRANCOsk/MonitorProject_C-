using WebFEB.Models;

namespace WebFEB.Storage
{
    public class PersonStorage
    {
        public PersonStorage()
        {
            PersonDTO person1 = new PersonDTO
            {
                Name = "John Doe",
                Email = "doe@gmail.com",
                Credit = 1000
            };
            PersonDTO person2 = new PersonDTO
            {
                Name = "Jane Smith",
                Email = "smith@gmail.com",
                Credit = 2000
            };

            PersonDTO person3 = new PersonDTO
            {
                Name = "Alice Johnson",
                Email = "johnson@gmail.com",
                Credit = 1500

            };

            Persons.Add(person1);
            Persons.Add(person2);
            Persons.Add(person3);
        }

        public List<PersonDTO> Persons { get; set; } = new List<PersonDTO>();
    }
}
