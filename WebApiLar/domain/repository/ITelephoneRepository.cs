using WebApiLar.Domain.Entity;

namespace WebApiLar.Domain.Repository
{
    public interface ITelephoneRepository
    {
        public Task<Telephone> save(Telephone telephone);
        public List<Telephone> getList();
        public Telephone findById(long id);
    }
}