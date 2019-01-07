using System;
using System.Collections.Generic;
using System.Threading;
using RestWithAspNetCore2Udemy.Model;

namespace RestWithAspNetCore2Udemy.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonBusiness _repository;

        public PersonBusinessImpl(IPersonBusiness repository)
        {
            _repository = repository;
        }

        private volatile int count;

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public bool Exists(long? id)
        {
            throw new NotImplementedException();
        }
    }
}
