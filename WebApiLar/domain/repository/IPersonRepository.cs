using WebApiLar.Domain.Entity;

namespace WebApiLar.Domain.Repository
{
    public interface IPersonRepository
    {
        public Task<Person> save(Person person);
        public Person findById(long id);
    }
}