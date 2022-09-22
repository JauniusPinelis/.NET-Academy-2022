using FirstWebApi.Models;

namespace FirstWebApi.Services
{
    public class PersonService
    {
        private List<Person> _persons = new List<Person>();

        public void Add(Person person)
        {
            _persons.Add(person);
        }

        public void Update(Person person)
        {
            var existingPerson = GetById(person.Id);

            existingPerson.LastName = person.LastName;
            existingPerson.FirstName = person.FirstName;
        }

        public List<Person> GetAll()
        {
            return _persons;
        }

        public Person GetById(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id.Equals(id));

            if (person == null)
            {
                throw new ArgumentNullException("person not found");
            }

            return person;
        }

        public void Remove(int id)
        {
            var person = GetById(id);

            _persons.Remove(person);
        }
    }
}
