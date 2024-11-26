using WebApiLar.Domain.Entity;
using WebApiLar.Domain.Entity.Enum;
using WebApiLar.Domain.Repository;
using WebApiLar.Infra.Database;

namespace WebApiLar.Infra.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private AppDbContext appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Person> getList()
        {
            List<Person> objectListDomain = new List<Person>();
            List<Database.Models.Person> objectListModel = 
            appDbContext.people.Where(x => x.active == Active.ACTIVE).ToList();
            foreach(var item in objectListModel)
            {
                objectListDomain.Add(this.fillObject(item));
            }
            return objectListDomain;
        }

        public Person findById(long id)
        {
            Database.Models.Person? objectModel = appDbContext.
            people.Where(x => x.idPerson == id).FirstOrDefault();

            return this.fillObject(objectModel);
        }
        public async Task<Person> save(Person person)
        {
            Database.Models.Person objectModel = new Database.Models.Person(
                person.idPerson, person.name, person.cpf, person.dateBirth, person.active);
                if(objectModel.idPerson > 0)
                {
                    appDbContext.people.Update(objectModel);
                }else
                {
                    appDbContext.people.Add(objectModel);
                }
                
                await this.appDbContext.SaveChangesAsync();
                return new Person(objectModel.idPerson, objectModel.name, objectModel.cpf!, objectModel.dateBirth!, objectModel.active!);
        }

        private Person fillObject(Database.Models.Person? model){
            if(model != null){
                long idObject = (long)model.idPerson;
                string name = model.name ?? string.Empty;
                string cpf = model.cpf ?? string.Empty;
                string date = model.dateBirth ?? string.Empty;
                string active = model.active ?? string.Empty;
                return new Person(idObject, name, cpf, date, active);
            }
            throw new KeyNotFoundException("Pessoa não encontrada");
        }
    }
}