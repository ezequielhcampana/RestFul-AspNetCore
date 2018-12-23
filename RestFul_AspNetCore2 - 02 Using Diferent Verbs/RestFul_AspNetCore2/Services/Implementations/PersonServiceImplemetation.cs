using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestFul_AspNetCore2.Model;
using System.Threading;

namespace RestFul_AspNetCore2.Services.Implementations
{
    public class PersonServiceImplemetation : IPersonService
    {
        private volatile int count;

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person Last Name" + i,
                Address = "Some Address" + i,
                Gender = "Male"
            };
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Ezequiel Henrique",
                LastName = "Campana",
                Address = "Rual Alcebíades Fontes Leite, 50",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
