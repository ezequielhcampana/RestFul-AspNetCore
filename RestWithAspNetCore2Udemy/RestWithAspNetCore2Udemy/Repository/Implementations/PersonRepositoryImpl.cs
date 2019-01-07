using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetCore2Udemy.Model;
using RestWithAspNetCore2Udemy.Model.Context;
using RestWithAspNetCore2Udemy.Business;

namespace RestWithAspNetCore2Udemy.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonBusiness
    {
        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        private volatile int count;

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if(result != null)
                {
                    _context.Persons.Remove(result);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id))
                return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

        public bool Exists(long? id)
        {
            throw new NotImplementedException();
        }
    }
}
