using RestFul_AspNetCore2.Model;
using System.Collections.Generic;

namespace RestFul_AspNetCore2.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
