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

        public List<Person> GetAll()
        {
            return _persons;
        }

        public Person GetById(int id)
        {
            return _persons.FirstOrDefault(p => p.Equals(id));
        }
    }
}
