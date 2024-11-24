using WebApiLar.Domain.Entity;

namespace WebApiLar.Domain.Repository
{
    public interface IPersonRepository
    {
        public Task<Person> save(Person person);
        public List<Person> getList();
        public Person findById(long id);
    }
}